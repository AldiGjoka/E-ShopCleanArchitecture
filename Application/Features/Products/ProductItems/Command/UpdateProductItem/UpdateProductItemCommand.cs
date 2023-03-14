using Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.ProductItems.Command.UpdateProductItem
{
    public record UpdateProductItemCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }

    }


    public class UpdateProductItemCommandHandler : IRequestHandler<UpdateProductItemCommand>
    {
        private readonly IProductItemService _productItemService;
        public UpdateProductItemCommandHandler(IProductItemService productItemService)
        {
            _productItemService = productItemService;
        }

        public async Task Handle(UpdateProductItemCommand request, CancellationToken cancellationToken)
        {
            var productToBeUpdated = await _productItemService.GetById(request.Id);

            if(productToBeUpdated == null)
                throw new NotFoundException(nameof(ProductItem), request.Id);

            productToBeUpdated.UpdateDetails(request.Name, request.Description, request.Price);
            productToBeUpdated.UpdateProductBrand(request.ProductBrandId);
            productToBeUpdated.UpdateProductType(request.ProductTypeId);
            productToBeUpdated.UpdatePictureUri(request.PictureUri);

            await _productItemService.UpdateAsync(productToBeUpdated);
        }
    }
}
