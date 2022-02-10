using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Application.v1.Models;
using MachiKoro.Persistence.Identity.Extensions;
using MachiKoro.Persistence.Identity.Models;
using MachiKoro.Persistence.Identity.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
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
        private readonly IConfiguration _configuration;
        private readonly IdentityDataContext _identityDataContext;

        public IdentityService(
            UserManager<ApplicationUser> userManager,
            Token token,
            IConfiguration configuration, 
            IdentityDataContext identityDataContext)
        {
            _userManager = userManager;
            _token = token;
            _configuration = configuration;
            _identityDataContext = identityDataContext;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return user.UserName;
        }

        public async Task<(Result Result, Result TokenResponse, string UserId)> CreateUserAsync(string userName, string email, string password)
        {
            var userExists = await _userManager.FindByNameAsync(userName);
            if (userExists != null)
            {
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

                    return (result.ToApplicationResult(), new TokenResponse(jwtToken).ToApplicationResult(), user.Id);
                }
            }

            return (result.ToApplicationResult(), null, null);
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

        public async Task<(Result, string)> AuthorizeAsync(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return (null, null);
            }

            var isCorrect = await _userManager.CheckPasswordAsync(user, password);

            if (!isCorrect)
            {
            }

            var jwtToken = await GenerateJwtToken(user);

            return (new TokenResponse(jwtToken).ToApplicationResult(), user.Id);
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            return user != null ? await DeleteUserAsync(user) : Result.Success();
        }

        public async Task<Result> DeleteUserAsync(ApplicationUser user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }

        public async Task<Result> RefreshToken(string token, string ipAddress)
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
            var newRefreshToken = rotateRefreshToken(refreshToken, ipAddress);
            _identityDataContext.RefreshTokens.Add(newRefreshToken);

            // remove old refresh tokens from user
            removeOldRefreshTokens(user);

            // save changes to db
            _identityDataContext.Update(user);
            _identityDataContext.SaveChanges();

            // generate new jwt
            var jwtToken = await GenerateJwtToken(user);

            var result = new Result(true, new List<string>())
            {
                Succeeded = true,
                RefreshToken = newRefreshToken.ToString(),
                Token = jwtToken
            };

            return result;
        }

        private ApplicationUser getUserByRefreshToken(string token)
        {
            var refreshToken = _identityDataContext.RefreshTokens.SingleOrDefault(t => t.Token == token);

            var user = _userManager.Users.SingleOrDefault(u => u.Id == refreshToken.UserId);

            return user;
        }

        private RefreshToken rotateRefreshToken(RefreshToken refreshToken, string ipAddress)
        {
            var newRefreshToken = GenerateRefreshToken(ipAddress);
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
                    new Claim(ClaimTypes.Email, user.Email),
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

        private RefreshToken GenerateRefreshToken(string ipAddress)
        {
            var refreshToken = new RefreshToken
            {
                Token = getUniqueToken(),
                // token is valid for 7 days
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress
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

        //private async Task<Result> GenerateJwtToken(IdentityUser user)
        //{
        //    var jwtTokenHandler = new JwtSecurityTokenHandler();

        //    var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[]
        //        {
        //            new Claim("Id", user.Id),
        //            new Claim(JwtRegisteredClaimNames.Email, user.Email),
        //            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //        }),
        //        Expires = DateTime.UtcNow.AddSeconds(30), // 5-10
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        //    var jwtToken = jwtTokenHandler.WriteToken(token);

        //    var refreshToken = new RefreshToken()
        //    {
        //        JwtId = token.Id,
        //        IsUsed = false,
        //        IsRevorked = false,
        //        UserId = user.Id,
        //        AddedDate = DateTime.UtcNow,
        //        ExpiryDate = DateTime.UtcNow.AddMonths(6),
        //        Token = RandomString(35) + Guid.NewGuid()
        //    };

        //    await _apiDbContext.RefreshTokens.AddAsync(refreshToken);
        //    await _apiDbContext.SaveChangesAsync();

        //    return new AuthResult()
        //    {
        //        Token = jwtToken,
        //        Success = true,
        //        RefreshToken = refreshToken.Token
        //    };
        //}
    }
}