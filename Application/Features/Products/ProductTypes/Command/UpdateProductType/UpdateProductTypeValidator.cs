using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.ProductTypes.Command.UpdateProductType
{
    public class UpdateProductTypeValidator : AbstractValidator<UpdateProductTypeCommand>
    {
        private readonly IProductTypeService _productTypeService;
        public UpdateProductTypeValidator(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("You must provide a brand name")
                .NotNull().WithMessage("You must provide a brand name")
                .MaximumLength(50).WithMessage("Lenght must not exceed 50 characters")
                .MustAsync(BeUniqueTitle).WithMessage("The specified title already excists")
                ;
        }

        private async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
        {
            var result = await _productTypeService.GetProductTypeByName(title);

            return !result;
        }
    }
}
