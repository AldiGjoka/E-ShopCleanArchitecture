using Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.ProductTypes.Query.GetProductTypeById
{
    public record GetProductTypeByIdQuery : IRequest<ProductType>
    {
        public int Id { get; set; }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductTypeByIdQuery, ProductType>
    {
        private readonly IProductTypeService _productTypeService;
        public GetProductByIdQueryHandler(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        public async Task<ProductType> Handle(GetProductTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productTypeService.GetById(request.Id);

            if (product == null)
                throw new NotFoundException(nameof(ProductType), request.Id);

            return product;
        }
    }
}
