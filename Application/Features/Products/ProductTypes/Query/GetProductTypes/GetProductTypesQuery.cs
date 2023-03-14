using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.ProductTypes.Query.GetProductTypes
{
    public record GetProductTypesQuery : IRequest<List<ProductType>>
    {
    }


    public class GetProductTypesQueryHandler : IRequestHandler<GetProductTypesQuery, List<ProductType>>
    {
        private readonly IProductTypeService _productTypeService;
        public GetProductTypesQueryHandler(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        public async Task<List<ProductType>> Handle(GetProductTypesQuery request, CancellationToken cancellationToken)
        {
            var products = (await _productTypeService.GetAllAsync()).ToList();

            return products;
        }
    }
}
