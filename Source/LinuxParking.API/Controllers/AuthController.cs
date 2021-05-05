using System.Threading.Tasks;
using AutoMapper;
using LinuxParking.API.Configuration;
using LinuxParking.API.Domain.Resources;
using LinuxParking.API.Domain.Response;
using LinuxParking.API.Domain.Services;
using LinuxParking.API.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LinuxParking.API.Controllers
{
    [Route("/api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<AuthResource, IdentityUser>(resource);

            var res = await _authService.RegisterAsync(user, resource.Password);

            if (!res.Success)
                return BadRequest(res.Message);

            return Created("", res);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<AuthResource, IdentityUser>(resource);

            var res = await _authService.LoginAsync(user, resource.Password);

            if (!res.Success)
                return BadRequest(res.Message);

            return Created("", res);
        }
    }
}