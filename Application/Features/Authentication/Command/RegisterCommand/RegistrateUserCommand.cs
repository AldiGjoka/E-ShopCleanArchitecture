using Application.Common.Interfaces.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Command.RegisterCommand
{
    public record RegistrateUserCommand : IRequest<RegistrationResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class RegistrateUserCommandHandler : IRequestHandler<RegistrateUserCommand, RegistrationResponse>
    {
        private readonly IAuthService _authService;
        public RegistrateUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<RegistrationResponse> Handle(RegistrateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new RegistrationRequest(request.FirstName, request.LastName, request.Email, request.UserName, request.Password);

            var result = await _authService.RegisterAsync(user);

            return result;
        }
    }
}
