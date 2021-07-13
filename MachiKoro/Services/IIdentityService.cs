using MachiKoro.Api.DomainModels;
using System.Threading.Tasks;

namespace MachiKoro.Api.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string userName, string email, string password);

        Task<AuthenticationResult> LoginAsync(string email, string password);
        
        //Task<AuthenticationResult> LogoutAsync();

        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
    }
}
