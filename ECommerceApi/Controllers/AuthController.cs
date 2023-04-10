using Application.Common.Interfaces.Auth;
using Application.Features.Authentication.Command.AuthCommand;
using Application.Features.Authentication.Command.RegisterCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMediator _mediator;
        public AuthController(IAuthService authService, IMediator mediator)
        {
            _authService = authService;
            _mediator = mediator;
        }

        [HttpPost("/authenticate")]
        public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthUserCommand user)
        {
            var result = await _mediator.Send(user);

            return Ok(result);

        }

        [HttpPost("/register")]
        public async Task<ActionResult<RegistrationResponse>> Registrate([FromBody] RegistrateUserCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
