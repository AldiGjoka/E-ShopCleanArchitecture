using Application.Common.Interfaces.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("/authenticate")]
        public async Task<ActionResult<AuthResponse>> Authenticate(AuthRequest request)
        {
            var result = await _authService.AuthenticateAsync(request);
            return Ok(result);

        }

        [HttpPost("/register")]
        public async Task<ActionResult<RegistrationResponse>> Registrate(RegistrationRequest request)
        {
            var result = await _authService.RegisterAsync(request);
            return Ok(result);
        }
    }
}
