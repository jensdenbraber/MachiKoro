using MachiKoro.Api.Options;
using MachiKoro.Persistence;
using MachiKoro.Persistence.Identity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using System.Text;

namespace MachiKoro.Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class AuthenticationServicesExtensions
    {
        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services//AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddIdentity<ApplicationUser, IdentityRole>()
                    .AddDefaultTokenProviders()
                    .AddUserManager<UserManager<ApplicationUser>>()
                    .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddEntityFrameworkStores<IdentityDataContext>();

            var jwtSettings = new JwtSettings();
            configuration.Bind(nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                ValidateIssuer = true,
                ValidIssuer = "http://mysite.com",
                ValidAudience = "http://mysite.com",
                ValidateAudience = true,
                RequireExpirationTime = false,
                ValidateLifetime = true,
                NameClaimType = ClaimTypes.NameIdentifier,
                ClockSkew = TimeSpan.Zero
            };

            //Token token = configuration.GetSection("token").Get<Token>();
            //byte[] secret = Encoding.ASCII.GetBytes(token.Secret);


            //var tokenValidationParameters = new TokenValidationParameters
            //{
            //    ClockSkew = TimeSpan.Zero,
            //    ValidateIssuer = true,
            //    ValidateAudience = true,
            //    ValidateLifetime = true,
            //    ValidateIssuerSigningKey = true,
            //    ValidIssuer = token.Issuer,
            //    ValidAudience = token.Audience,
            //    IssuerSigningKey = new SymmetricSecurityKey(secret),
            //    NameClaimType = ClaimTypes.NameIdentifier,
            //    RequireSignedTokens = true,
            //    RequireExpirationTime = true
            //};

            //services.AddSingleton(tokenValidationParameters);

            services
                .AddAuthentication(
                    options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                .AddJwtBearer(
                    options =>
                    {
                        options.RequireHttpsMetadata = true;
                        options.SaveToken = true;
                        //options.ClaimsIssuer = token.Issuer;
                        options.IncludeErrorDetails = true;
                        options.Validate(JwtBearerDefaults.AuthenticationScheme);
                        options.TokenValidationParameters = tokenValidationParameters;
                            //new TokenValidationParameters
                            //{
                            //    ClockSkew = TimeSpan.Zero,
                            //    ValidateIssuer = true,
                            //    ValidateAudience = true,
                            //    ValidateLifetime = true,
                            //    ValidateIssuerSigningKey = true,
                            //    ValidIssuer = token.Issuer,
                            //    ValidAudience = token.Audience,
                            //    IssuerSigningKey = new SymmetricSecurityKey(secret),
                            //    NameClaimType = ClaimTypes.NameIdentifier,
                            //    RequireSignedTokens = true,
                            //    RequireExpirationTime = true
                            //};
                    });



            return services;
        }
    }
}
