﻿namespace MachiKoro.Api.Services
{
    public class IdentityService : IIdentityService
    {
        //private readonly UserManager<IdentityUser> _userManager;
        ////private readonly SignInManager<IdentityUser> _signInManager;
        ////private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly JwtSettings _jwtSettings;
        //private readonly TokenValidationParameters _tokenValidationParameters;
        //private readonly IdentityDataContext _identityDataContext;
        

        //public IdentityService(UserManager<IdentityUser> userManager, JwtSettings jwtSettings, TokenValidationParameters tokenValidationParameters, IdentityDataContext identityDataContext)
        //{
        //    _userManager = userManager;
        //    //_signInManager = signInManager;
        //    _jwtSettings = jwtSettings;
        //    _tokenValidationParameters = tokenValidationParameters;
        //    _identityDataContext = identityDataContext;
        //    //_roleManager = roleManager;
        //}

        //public async Task<AuthenticationResult> LoginAsync(string email, string password)
        //{
        //    var user = await _userManager.FindByEmailAsync(email);

        //    //SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
            
        //    if (user == null)
        //    {
        //        return new AuthenticationResult
        //        {
        //            Errors = new[] { "User does not exist" }
        //        };
        //    }

        //    var userHasValidPassword = await _userManager.CheckPasswordAsync(user, password);

        //    if (!userHasValidPassword)
        //    {
        //        return new AuthenticationResult
        //        {
        //            Errors = new[] { "User/password combination is wrong" }
        //        };
        //    }

        //    return await GenerateAuthenticationResultForUserAsync(user);
        //}

        //public async Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken)
        //{
        //    var validatedToken = GetPrincipalFromToken(token);

        //    if (validatedToken == null)
        //    {
        //        return new AuthenticationResult { Errors = new[] { "Invalid Token" } };
        //    }

        //    var expiryDateUnix =
        //        long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

        //    var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
        //        .AddSeconds(expiryDateUnix);

        //    if (expiryDateTimeUtc > DateTime.UtcNow)
        //    {
        //        return new AuthenticationResult { Errors = new[] { "This token hasn't expired yet" } };
        //    }

        //    var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

        //    //var storedRefreshToken = await _identityDataContext.RefreshTokens.SingleOrDefaultAsync(x => x.Token == refreshToken);

        //    //if (storedRefreshToken == null)
        //    //{
        //    //    return new AuthenticationResult { Errors = new[] { "This refresh token does not exist" } };
        //    //}

        //    //if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
        //    //{
        //    //    return new AuthenticationResult { Errors = new[] { "This refresh token has expired" } };
        //    //}

        //    //if (storedRefreshToken.Invalidated)
        //    //{
        //    //    return new AuthenticationResult { Errors = new[] { "This refresh token has been invalidated" } };
        //    //}

        //    //if (storedRefreshToken.Used)
        //    //{
        //    //    return new AuthenticationResult { Errors = new[] { "This refresh token has been used" } };
        //    //}

        //    //if (storedRefreshToken.JwtId != jti)
        //    //{
        //    //    return new AuthenticationResult { Errors = new[] { "This refresh token does not match this JWT" } };
        //    //}

        //    //storedRefreshToken.Used = true;
        //    //_identityDataContext.RefreshTokens.Update(storedRefreshToken);
        //    await _identityDataContext.SaveChangesAsync();

        //    var user = await _userManager.FindByIdAsync(validatedToken.Claims.Single(x => x.Type == "id").Value);
        //    return await GenerateAuthenticationResultForUserAsync(user);
        //}

        //public async Task<AuthenticationResult> RegisterAsync(string userName, string email, string password)
        //{
        //    var existingUserName = await _userManager.FindByNameAsync(userName);

        //    if (existingUserName != null)
        //    {
        //        return new AuthenticationResult
        //        {
        //            Errors = new[] { "User with this Username already exists" }
        //        };
        //    }

        //    var existingUser = await _userManager.FindByEmailAsync(email);

        //    if (existingUser != null)
        //    {
        //        return new AuthenticationResult
        //        {
        //            Errors = new[] { "User with this email address already exists" }
        //        };
        //    }

        //    var newUserId = Guid.NewGuid();
        //    var newUser = new IdentityUser
        //    {
        //        Id = newUserId.ToString(),
        //        Email = email,
        //        UserName = userName                
        //    };

        //    var createdUser = await _userManager.CreateAsync(newUser, password);

        //    if (!createdUser.Succeeded)
        //    {
        //        return new AuthenticationResult
        //        {
        //            Errors = createdUser.Errors.Select(x => x.Description)
        //        };
        //    }

        //    return await GenerateAuthenticationResultForUserAsync(newUser);
        //}

        //private ClaimsPrincipal GetPrincipalFromToken(string token)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    try
        //    {
        //        var tokenValidationParameters = _tokenValidationParameters.Clone();
        //        tokenValidationParameters.ValidateLifetime = false;
        //        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
        //        if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
        //        {
        //            return null;
        //        }

        //        return principal;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}


        //private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        //{
        //    return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
        //           jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
        //               StringComparison.InvariantCultureIgnoreCase);
        //}

        //private async Task<AuthenticationResult> GenerateAuthenticationResultForUserAsync(IdentityUser user)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

        //    var claims = new List<Claim>
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        //        new Claim("id", user.Id)
        //    };

        //    //var userClaims = await _userManager.GetClaimsAsync(user);
        //    //claims.AddRange(userClaims);

        //    //var userRoles = await _userManager.GetRolesAsync(user);
        //    //foreach (var userRole in userRoles)
        //    //{
        //    //    claims.Add(new Claim(ClaimTypes.Role, userRole));
        //    //    var role = await _roleManager.FindByNameAsync(userRole);
        //    //    if (role == null) continue;
        //    //    var roleClaims = await _roleManager.GetClaimsAsync(role);

        //    //    foreach (var roleClaim in roleClaims)
        //    //    {
        //    //        if (claims.Contains(roleClaim))
        //    //            continue;

        //    //        claims.Add(roleClaim);
        //    //    }
        //    //}

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(claims),
        //        Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifetime),
        //        SigningCredentials =
        //            new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var token = tokenHandler.CreateToken(tokenDescriptor);

        //    var refreshToken = new Persistence.Models.RefreshToken
        //    {
        //        JwtId = token.Id,
        //        UserId = user.Id,
        //        CreationDate = DateTime.UtcNow,
        //        ExpiryDate = DateTime.UtcNow.AddMonths(6)
        //    };

        //    //await _identityDataContext.RefreshTokens.AddAsync(refreshToken);
        //    await _identityDataContext.SaveChangesAsync();

        //    return new AuthenticationResult
        //    {
        //        Success = true,
        //        Token = tokenHandler.WriteToken(token),
        //        RefreshToken = refreshToken.Token
        //    };
        //}

        //public Task<AuthenticationResult> LogoutAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}