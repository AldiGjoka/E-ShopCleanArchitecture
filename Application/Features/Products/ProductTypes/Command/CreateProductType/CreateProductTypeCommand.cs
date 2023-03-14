using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.ProductTypes.Command.CreateProductType
{
    public record CreateProductTypeCommand : IRequest<ProductType>
    {
        public string Type { get; set; }
    }

    public class CreateProductTypeCommandHandler : IRequestHandler<CreateProductTypeCommand, ProductType>
    {
        private readonly IProductTypeService _productTypeService;
        private readonly IMapper _mapper;
        public CreateProductTypeCommandHandler(IProductTypeService productTypeService, IMapper mapper)
        {
            _productTypeService = productTypeService;
            _mapper = mapper;
        }

        public async Task<ProductType> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductType(request.Type);

            var createdProduct = await _productTypeService.CreateAsync(product);

            return createdProduct;
        }
    }
}
