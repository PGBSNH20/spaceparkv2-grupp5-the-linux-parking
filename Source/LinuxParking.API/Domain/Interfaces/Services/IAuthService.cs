using System.Threading.Tasks;
using LinuxParking.API.Domain.Response;
using Microsoft.AspNetCore.Identity;

namespace LinuxParking.API.Domain.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(IdentityUser user, string password);
        Task<AuthResponse> LoginAsync(IdentityUser user, string password);
    }
}