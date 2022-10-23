using MachiKoro.Api.Options;
using MachiKoro.Persistence.Data;
using MachiKoro.Persistence.Identity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using System.Text;

namespace MachiKoro.Api.Extensions;

[ExcludeFromCodeCoverage]
public static class AuthenticationServicesExtensions
{
    public static IServiceCollection AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Adds Microsoft Identity platform (AAD v2.0) support to protect this Api
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(options =>
                {
                    configuration.Bind("AzureAd", options);
                    options.Events = new JwtBearerEvents();

                    /// <summary>
                    /// Below you can do extended token validation and check for additional claims, such as:
                    ///
                    /// - check if the caller's tenant is in the allowed tenants list via the 'tid' claim (for multi-tenant applications)
                    /// - check if the caller's account is homed or guest via the 'acct' optional claim
                    /// - check if the caller belongs to right roles or groups via the 'roles' or 'groups' claim, respectively
                    ///
                    /// Bear in mind that you can do any of the above checks within the individual routes and/or controllers as well.
                    /// For more information, visit: https://docs.microsoft.com/azure/active-directory/develop/access-tokens#validate-the-user-has-permission-to-access-this-data
                    /// </summary>

                    //options.Events.OnTokenValidated = async context =>
                    //{
                    //    string[] allowedClientApps = { /* list of client ids to allow */ };

                    //    string clientappId = context?.Principal?.Claims
                    //        .FirstOrDefault(x => x.Type == "azp" || x.Type == "appid")?.Value;

                    //    if (!allowedClientApps.Contains(clientappId))
                    //    {
                    //        throw new System.Exception("This client is not authorized");
                    //    }
                    //};
                }, options => { configuration.Bind("AzureAd", options); });

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApi(configuration.GetSection("AzureAd"));

        //services//AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        //        .AddIdentity<ApplicationUser, IdentityRole>()
        //        .AddDefaultTokenProviders()
        //        .AddUserManager<UserManager<ApplicationUser>>()
        //        .AddSignInManager<SignInManager<ApplicationUser>>()
        //    .AddEntityFrameworkStores<IdentityDataContext>();

        //var jwtSettings = new JwtSettings();
        //configuration.Bind(nameof(jwtSettings), jwtSettings);
        //services.AddSingleton(jwtSettings);

        //var tokenValidationParameters = new TokenValidationParameters
        //{
        //    ValidateIssuerSigningKey = true,
        //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("jwtSettings.Secret")),
        //    ValidateIssuer = true,
        //    ValidIssuer = "http://mysite.com",
        //    ValidAudience = "http://mysite.com",
        //    ValidateAudience = true,
        //    RequireExpirationTime = false,
        //    ValidateLifetime = true,
        //    NameClaimType = ClaimTypes.NameIdentifier,
        //    ClockSkew = TimeSpan.Zero
        //};

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

        //services
        //    .AddAuthentication(
        //        options =>
        //        {
        //            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        //            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //        })
        //    .AddJwtBearer(
        //        options =>
        //        {
        //            options.RequireHttpsMetadata = true;
        //            options.SaveToken = true;
        //            //options.ClaimsIssuer = token.Issuer;
        //            options.IncludeErrorDetails = true;
        //            options.Validate(JwtBearerDefaults.AuthenticationScheme);
        //            options.TokenValidationParameters = tokenValidationParameters;
        //            //new TokenValidationParameters
        //            //{
        //            //    ClockSkew = TimeSpan.Zero,
        //            //    ValidateIssuer = true,
        //            //    ValidateAudience = true,
        //            //    ValidateLifetime = true,
        //            //    ValidateIssuerSigningKey = true,
        //            //    ValidIssuer = token.Issuer,
        //            //    ValidAudience = token.Audience,
        //            //    IssuerSigningKey = new SymmetricSecurityKey(secret),
        //            //    NameClaimType = ClaimTypes.NameIdentifier,
        //            //    RequireSignedTokens = true,
        //            //    RequireExpirationTime = true
        //            //};
        //        });

        return services;
    }
}