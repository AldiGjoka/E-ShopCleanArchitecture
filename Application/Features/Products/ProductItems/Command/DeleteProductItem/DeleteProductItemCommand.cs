using Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.ProductItems.Command.DeleteProductItem
{
    public record DeleteProductItemCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteProductItemCommandHandler : IRequestHandler<DeleteProductItemCommand>
    {
        private readonly IProductItemService _productItemService;
        public DeleteProductItemCommandHandler(IProductItemService productItemService)
        {
            _productItemService = productItemService;
        }

        public async Task Handle(DeleteProductItemCommand request, CancellationToken cancellationToken)
        {
            var productItemToBeDeleted = await _productItemService.GetById(request.Id);

            if(productItemToBeDeleted == null)
                throw new NotFoundException(nameof(ProductItem), request.Id);

            await _productItemService.DeleteAsync(request.Id);
        }
    }
}
