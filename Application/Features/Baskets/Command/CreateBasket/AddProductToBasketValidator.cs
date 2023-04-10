using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Baskets.Command.CreateBasket
{
    public class AddProductToBasketValidator : AbstractValidator<AddProductToBasketCommand>
    {
        public AddProductToBasketValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id must be not empty")
                .NotNull().WithMessage("Id must not be null");

            RuleFor(p => p.BuyerId)
                .NotEmpty().WithMessage("Id must be not empty")
                .NotNull().WithMessage("Id must not be null");

            RuleFor(p => p.ProductTypeId)
                .NotEmpty().WithMessage("Id must be not empty")
                .NotNull().WithMessage("Id must not be null");

        }
    }
}
