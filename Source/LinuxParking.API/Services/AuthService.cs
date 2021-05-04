using System.Threading.Tasks;
using System.Linq;
using LinuxParking.API.Utils;
using LinuxParking.API.Configuration;
using LinuxParking.API.Domain.Response;
using LinuxParking.API.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace LinuxParking.API.Services
{
  public class AuthService : IAuthService
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IOptions<JwtConfig> _jwtConfig;
    public AuthService(UserManager<IdentityUser> userManager, IOptions<JwtConfig> jwtConfig)
    {
      _userManager = userManager;
      _jwtConfig = jwtConfig;
    }

    public async Task<AuthResponse> RegisterAsync(IdentityUser user, string password)
    {
        var existing = await _userManager.FindByNameAsync(user.UserName);

        if (existing != null)
            return new AuthResponse("User already exists");

        var isCreated = await _userManager.CreateAsync(user, password);

        if (!isCreated.Succeeded)
            return new AuthResponse(isCreated.Errors.Select(e => e.Description).First());

        var token = Jwt.GenerateToken(user, _jwtConfig.Value.Secret);

        return new AuthResponse("Account created", token);
    }
  }
}