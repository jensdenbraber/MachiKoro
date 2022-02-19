using MachiKoro.Application.v1.Exceptions;
using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Application.v1.Models;
using MachiKoro.Persistence.Identity.Models;
using MachiKoro.Persistence.Identity.Models.Authentication;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MachiKoro.Persistence.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Token _token;
        private readonly IdentityDataContext _identityDataContext;

        public IdentityService(
            UserManager<ApplicationUser> userManager,
            Token token,
            IdentityDataContext identityDataContext)
        {
            _userManager = userManager;
            _token = token;
            _identityDataContext = identityDataContext;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return user.UserName;
        }

        public async Task<Unit> CreateUserAsync(string userName, string email, string password, string ipAdress)
        {
            var userExists = await _userManager.FindByNameAsync(userName);
            if (userExists != null)
            {
                throw new UserAlreadyExistsException(userName);
            }

            var user = new ApplicationUser
            {
                UserName = userName,
                Email = email,
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var addToRolesResult = await _userManager.AddToRoleAsync(user, "Member");

                if (addToRolesResult.Succeeded)
                {
                    var jwtToken = await GenerateJwtToken(user);
                    var refreshToken = GenerateRefreshToken(ipAdress, user.Id);

                    await _identityDataContext.RefreshTokens.AddAsync(refreshToken);
                    await _identityDataContext.SaveChangesAsync();

                    return Unit.Value;
                }
            }

            throw new RegisterException(result.Errors);
        }

        public async Task<bool> IsInRoleAsync(string userId, string role)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            return user != null && await _userManager.IsInRoleAsync(user, role);
        }

        public async Task<bool> AuthorizeByIdAsync(string userId, string policyName)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthorizeResult> AuthorizeAsync(string userName, string password, string ipAdress)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                throw new LoginException(userName, password);
            }

            var isCorrect = await _userManager.CheckPasswordAsync(user, password);

            if (!isCorrect)
            {
                throw new LoginException(userName, password);
            }

            var jwtToken = await GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken(ipAdress, user.Id);

            var authorizeResult = new AuthorizeResult
            {
                UserName = userName,
                Token = jwtToken,
                RefreshToken = refreshToken.Token
            };

            return authorizeResult;
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            return user != null ? await DeleteUserAsync(user) : false;
        }

        public async Task<bool> DeleteUserAsync(ApplicationUser user)
        {
            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return true;
            }

            throw new DeleteUserException(result.Errors);
        }

        public async Task<RefreshTokenResult> RefreshToken(string token, string ipAddress)
        {
            var user = getUserByRefreshToken(token);
            var refreshToken = _identityDataContext.RefreshTokens.Single(x => x.Token == token);

            if (refreshToken.IsRevoked)
            {
                // revoke all descendant tokens in case this token has been compromised
                revokeDescendantRefreshTokens(refreshToken, user, ipAddress, $"Attempted reuse of revoked ancestor token: {token}");
                _identityDataContext.Update(user);
                _identityDataContext.SaveChanges();
            }

            if (!refreshToken.IsActive)
                throw new Exception("Invalid token");

            // replace old refresh token with a new one (rotate token)
            var newRefreshToken = rotateRefreshToken(refreshToken, ipAddress, user.Id);
            _identityDataContext.RefreshTokens.Add(newRefreshToken);

            // remove old refresh tokens from user
            removeOldRefreshTokens(user);

            // save changes to db
            _identityDataContext.Update(user);
            _identityDataContext.SaveChanges();

            // generate new jwt
            var jwtToken = await GenerateJwtToken(user);

            var refreshTokenResult = new RefreshTokenResult
            {
                RefreshToken = newRefreshToken.ToString(),
                Token = jwtToken
            };

            return refreshTokenResult;
        }

        private ApplicationUser getUserByRefreshToken(string token)
        {
            var refreshToken = _identityDataContext.RefreshTokens.SingleOrDefault(t => t.Token == token);

            var user = _userManager.Users.SingleOrDefault(u => u.Id == refreshToken.UserId);

            return user;
        }

        private RefreshToken rotateRefreshToken(RefreshToken refreshToken, string ipAddress, string userId)
        {
            var newRefreshToken = GenerateRefreshToken(ipAddress, userId);
            revokeRefreshToken(refreshToken, ipAddress, "Replaced by new token", newRefreshToken.Token);
            return newRefreshToken;
        }

        private void revokeDescendantRefreshTokens(RefreshToken refreshToken, ApplicationUser user, string ipAddress, string reason)
        {
            // recursively traverse the refresh token chain and ensure all descendants are revoked
            if (!string.IsNullOrEmpty(refreshToken.ReplacedByToken))
            {
                var childToken = _identityDataContext.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken.ReplacedByToken);
                if (childToken.IsActive)
                    revokeRefreshToken(childToken, ipAddress, reason);
                else
                    revokeDescendantRefreshTokens(childToken, user, ipAddress, reason);
            }
        }

        private void revokeRefreshToken(RefreshToken token, string ipAddress, string reason = null, string replacedByToken = null)
        {
            token.Revoked = DateTime.UtcNow;
            token.RevokedByIp = ipAddress;
            token.ReasonRevoked = reason;
            token.ReplacedByToken = replacedByToken;
        }

        private void removeOldRefreshTokens(ApplicationUser user)
        {
            // remove old inactive refresh tokens from user based on TTL in app settings
            //_identityDataContext.RefreshTokens.RemoveAll(x =>
            //    !x.IsActive &&
            //    x.Created.AddDays(_appSettings.RefreshTokenTTL) <= DateTime.UtcNow);
        }

        private async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            _token.Audience = "Member";
            _token.Expiry = 10000000;
            _token.Issuer = "Machi Koro";
            _token.RefreshExpiry = 10000000;
            _token.Secret = "E3238CFA-0449-47F0-BA46-C9136B9C5497";

            List<string> roles = (await _userManager.GetRolesAsync(user)).ToList();
            byte[] secret = Encoding.ASCII.GetBytes(_token.Secret);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Issuer = _token.Issuer,
                Audience = _token.Audience,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId", user.Id),
                    //new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, string.Join(",", roles))
                }),
                Expires = DateTime.UtcNow.AddMinutes(_token.Expiry),
                IssuedAt = DateTime.UtcNow,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }

        private RefreshToken GenerateRefreshToken(string ipAddress, string userId)
        {
            var refreshToken = new RefreshToken
            {
                Token = getUniqueToken(),
                // token is valid for 7 days
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress,
                UserId = userId
            };

            return refreshToken;

            string getUniqueToken()
            {
                // token is a cryptographically strong random sequence of values
                var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
                // ensure token is unique by checking against db
                var tokenIsUnique = !_identityDataContext.RefreshTokens.Any(t => t.Token == token);

                if (!tokenIsUnique)
                    return getUniqueToken();

                return token;
            }
        }
    }
}