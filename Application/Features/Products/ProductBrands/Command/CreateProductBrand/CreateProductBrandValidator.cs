using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.ProductBrands.Command.CreateProductBrand
{
    public class CreateProductBrandValidator : AbstractValidator<CreateProductBrandCommand>
    {
        private readonly IProductBrandService _productBrandService;
        public CreateProductBrandValidator(IProductBrandService productBrandService)
        {
            _productBrandService = productBrandService;

            RuleFor(x => x.BrandName)
                .NotEmpty().WithMessage("You must provide a brand name")
                .NotNull().WithMessage("You must provide a brand name")
                .MaximumLength(50).WithMessage("Lenght must not exceed 50 characters")
                .MustAsync(BeUniqueTitle).WithMessage("The specified title already excists");
        }

        private async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
        {
            var result = await _productBrandService.GetProductBrandByName(title);

            return !result;
        }
    }
}
