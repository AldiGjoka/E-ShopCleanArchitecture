using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Command.RegisterCommand
{
    public class RegistrateUserValidator : AbstractValidator<RegistrateUserCommand>
    {
        public RegistrateUserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email should not be empty")
                .NotNull().WithMessage("Email should not be empty")
                .EmailAddress().WithMessage("A valid email address is required.")
            ;

            RuleFor(p => p.Password).NotEmpty().WithMessage("Your password cannot be empty")
                .MinimumLength(8).WithMessage("Your password length must be at least 8 characters.")
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).")
                ;
        }
    }
}
