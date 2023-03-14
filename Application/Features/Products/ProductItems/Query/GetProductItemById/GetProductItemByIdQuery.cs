using Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.ProductItems.Query.GetProductItemById
{
    public record GetProductItemByIdQuery : IRequest<ProductItem>
    {
        public int Id { get; set; }
    }

    public class GetProductItemByIdQueryHandler : IRequestHandler<GetProductItemByIdQuery, ProductItem>
    {
        private readonly IProductItemService _productItemService;
        public GetProductItemByIdQueryHandler(IProductItemService productItemService)
        {
            _productItemService = productItemService;
        }

        public async Task<ProductItem> Handle(GetProductItemByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productItemService.GetProductItemWithBrandAndType(request.Id);

            if (product == null)
                throw new NotFoundException(nameof(ProductItem), request.Id);

            return product;
        }
    }
}
