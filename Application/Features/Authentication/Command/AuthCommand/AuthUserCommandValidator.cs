﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Command.AuthCommand
{
    public class AuthUserCommandValidator : AbstractValidator<AuthUserCommand>
    {
        public AuthUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email should not be empty")
                .NotNull().WithMessage("Email should not be empty")
                .EmailAddress().WithMessage("A valid email address is required.") //commented for testing purposes
                ;

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password should not be empty")
                .NotNull().WithMessage("Password should not be empty")
                .MinimumLength(8).WithMessage("Your password length must be at least 8 characters.")
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                //.Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).")
                ;

        }
    }
}
