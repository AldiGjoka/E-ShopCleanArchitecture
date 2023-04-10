using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Command.CreateOrders
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrdersCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.BuyerId)
                .NotEmpty().WithMessage("Buyer id must not be empty")
                .NotNull().WithMessage("Buyer id must not be empty")
                ;

            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Street must not be empty")
                .NotNull().WithMessage("Street must not be empty")
                ;

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City must not be empty")
                .NotNull().WithMessage("City must not be empty")
                ;

            RuleFor(x => x.State)
                .NotEmpty().WithMessage("State must not be empty")
                .NotNull().WithMessage("State must not be empty")
                ;

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country must not be empty")
                .NotNull().WithMessage("Country must not be empty")
                ;

            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("ZipCode must not be empty")
                .NotNull().WithMessage("ZipCode must not be empty")
                ;
        }
    }
}
