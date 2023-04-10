using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.ProductItems.Command.UpdateProductItem
{
    public class UpdateProductItemValidator : AbstractValidator<UpdateProductItemCommand>
    {
        public UpdateProductItemValidator()
        {
            RuleFor(X => X.Name)
                .NotEmpty().WithMessage("Name must not be empty")
                ;

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price must not be empty")
                ;

            RuleFor(x => x.ProductTypeId)
                .NotEmpty().WithMessage("ProductType must not be empty")
                ;

            RuleFor(x => x.ProductBrandId)
                .NotEmpty().WithMessage("ProductBrand must not be empty")
                ;
        }
    }
}
