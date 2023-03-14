using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.ProductBrands.Command.CreateProductBrand
{
    public record CreateProductBrandCommand : IRequest<ProductBrand>
    {
        public string BrandName { get; set; }
    }


    public class CreateProductBrandCommandHandler : IRequestHandler<CreateProductBrandCommand, ProductBrand>
    {
        private readonly IProductBrandService _productBrandService;
        private readonly IMapper _mapper;
        public CreateProductBrandCommandHandler(IProductBrandService productBrandService, IMapper mapper)
        {
            _productBrandService = productBrandService;
            _mapper = mapper;
        }

        public async Task<ProductBrand> Handle(CreateProductBrandCommand request, CancellationToken cancellationToken)
        {
            var productBrand = new ProductBrand(request.BrandName);
            var result = await _productBrandService.CreateAsync(productBrand);

            return result;
        }
    }
}
