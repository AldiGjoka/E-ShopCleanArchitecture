using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.ProductItems.Command.CreateProductItem
{
    public record CreateProductItemCommand : IRequest<ProductItem>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }
    }

    public class CreateProductItemCommandHandler : IRequestHandler<CreateProductItemCommand, ProductItem>
    {
        private readonly IProductItemService _productItemService;
        public CreateProductItemCommandHandler(IProductItemService productItemService)
        {
            _productItemService = productItemService;
        }

        public async Task<ProductItem> Handle(CreateProductItemCommand request, CancellationToken cancellationToken)
        {
            var productItem = new ProductItem(request.Name, request.Description, request.Price, 
                request.PictureUri, request.ProductTypeId, request.ProductBrandId);

            var product = await _productItemService.CreateAsync(productItem);

            return product;
        }
    }
}
