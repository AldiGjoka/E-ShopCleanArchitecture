using Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.ProductTypes.Command.DeleteProductType
{
    public record DeleteProductTypeCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteProductTypeCommandHandler : IRequestHandler<DeleteProductTypeCommand>
    {
        private readonly IProductTypeService _productTypeService;
        public DeleteProductTypeCommandHandler(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        public async Task Handle(DeleteProductTypeCommand request, CancellationToken cancellationToken)
        {
            var productToBeDeleted = await _productTypeService.GetById(request.Id);

            if (productToBeDeleted == null)
                throw new NotFoundException(nameof(ProductType), request.Id);

            await _productTypeService.DeleteAsync(request.Id);
        }
    }
}
