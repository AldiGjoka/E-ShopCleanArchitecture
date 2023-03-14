using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.ProductItems.Query.GetProductItemWithBrandAndType
{
    public record GetProductItemWithBrandAndTypeQuery : IRequest<List<ProductItem>>
    {
    }


    public class GetProductItemWithBrandAndTypeQueryHandler : IRequestHandler<GetProductItemWithBrandAndTypeQuery, List<ProductItem>>
    {
        private readonly IProductItemService _productItemService;
        public GetProductItemWithBrandAndTypeQueryHandler(IProductBrandService productBrandService,
            IProductTypeService productTypeService, IProductItemService productItemService)
        {
            _productItemService = productItemService;
        }

        public async Task<List<ProductItem>> Handle(GetProductItemWithBrandAndTypeQuery request, CancellationToken cancellationToken)
        {
            var products = (await _productItemService.GetAllAsync()).ToList();

            return products;
        }
    }
}
