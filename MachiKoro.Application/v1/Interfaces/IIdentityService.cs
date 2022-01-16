using MachiKoro.Application.v1.Models;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeByIdAsync(string userId, string policyName);
        Task<(Result Result, string UserId)> AuthorizeAsync(string userName, string password);

        Task<(Result Result, Result TokenResponse, string UserId)> CreateUserAsync(string userName, string email, string password);

        Task<Result> DeleteUserAsync(string userId);




        ///// <summary>
        /////     Validate the credentials entered when logging in.
        ///// </summary>
        ///// <param name="request"></param>
        ///// <param name="ipAddress"></param>
        ///// <returns></returns>
        //Task<TokenResponse> Authenticate(TokenRequest request, string ipAddress);

        ///// <summary>
        /////     If the refresh token is valid, a new JWT token will be issued containing the user details.
        ///// </summary>
        ///// <param name="refreshToken">An existing refresh token.</param>
        ///// <param name="ipAddress">The users current ip</param>
        ///// <returns>
        /////     <see cref="TokenResponse" />
        ///// </returns>
        //Task<TokenResponse> RefreshToken(string refreshToken, string ipAddress);


        ///// <summary>
        /////     Check if the credentials passed in are valid.
        ///// </summary>
        ///// <param name="username">The username to check.</param>
        ///// <param name="password">The matching password to verify.</param>
        ///// <returns>If the credentials are valid or not.</returns>
        //Task<bool> IsValidUser(string username, string password);

        ///// <summary>
        /////     Find an <see cref="ApplicationUser" /> by their email.
        ///// </summary>
        ///// <param name="email">
        /////     <see cref="ApplicationUser.Email" />
        ///// </param>
        ///// <returns>
        /////     <see cref="ApplicationUser" />
        ///// </returns>
        //Task<ApplicationUser> GetUserByEmail(string email);
    }
}