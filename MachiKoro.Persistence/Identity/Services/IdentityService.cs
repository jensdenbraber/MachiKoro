using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Application.v1.Models;
using MachiKoro.Core.Models;
using MachiKoro.Infrastructure.Identity.Models;
using MachiKoro.Infrastructure.Identity.Models.Authentication;
using MachiKoro.Persistence.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MachiKoro.Infrastructure.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
        private readonly IAuthorizationService _authorizationService;
        private readonly Token _token;
        //private readonly JwtConfig _jwtConfig;

        public IdentityService(
            UserManager<ApplicationUser> userManager,
            IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
            IAuthorizationService authorizationService,
            Token token)
            //IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _userManager = userManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _authorizationService = authorizationService;
            _token = token;
            //_jwtConfig = optionsMonitor.CurrentValue;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return user.UserName;
        }

        public async Task<(Result Result, Result TokenResponse, string UserId)> CreateUserAsync(string userName, string email, string password)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = email,
            };

            //// We can utilise the model
            //var existingUser = await _userManager.FindByEmailAsync(user.Email);
            ////var existingUserName = await _userManager.FindByNameAsync(user.UserName);


            //if (existingUser != null)
            //{
                var result = await _userManager.CreateAsync(user, password);

                if(result.Succeeded)
                {
                    var jwtToken = await GenerateJwtToken(user);

                    return (result.ToApplicationResult(), new TokenResponse(user, "", jwtToken).ToApplicationResult(), user.Id);
                }
            //}

            return (result.ToApplicationResult(), new TokenResponse(null, "", "").ToApplicationResult(), user.Id);
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

        public async Task<Result> AuthorizeAsync(string userName, string password)
        {
            var existingUser = await _userManager.FindByNameAsync(userName);

            if (existingUser == null)
            {
                return null;
            }

            var isCorrect = await _userManager.CheckPasswordAsync(existingUser, password);


            var principal = await _userClaimsPrincipalFactory.CreateAsync(existingUser);

            //var result = await _authorizationService.AuthorizeAsync(principal, policyName);

            string role = (await _userManager.GetRolesAsync(existingUser))[0];
            var jwtToken = await GenerateJwtToken(existingUser);

            return new TokenResponse(existingUser, role, jwtToken).ToApplicationResult();

            //return new Result().Token = jwtToken;
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

        private async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            string role = (await _userManager.GetRolesAsync(user))[0];
            byte[] secret = Encoding.ASCII.GetBytes(_token.Secret);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
{
                Issuer = _token.Issuer,
                Audience = _token.Audience,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId", user.Id),
                    new Claim("FullName", $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Email),
                    new Claim(ClaimTypes.Role, role)
}),
                Expires = DateTime.UtcNow.AddMinutes(_token.Expiry),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = handler.CreateToken(descriptor);
            return handler.WriteToken(token);
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