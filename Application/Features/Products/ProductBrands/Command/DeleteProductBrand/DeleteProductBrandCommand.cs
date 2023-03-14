using Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.ProductBrands.Command.DeleteProductBrand
{
    public class DeleteProductBrandCommand : IRequest
    {
        public int Id { get; set; }
    }


    public class UpdateProductBrandCommandHandler : IRequestHandler<DeleteProductBrandCommand>
    {
        private readonly IProductBrandService _productBrandService;
        public UpdateProductBrandCommandHandler(IProductBrandService productBrandService)
        {
            _productBrandService = productBrandService;
        }

        public async Task Handle(DeleteProductBrandCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _productBrandService.GetById(request.Id);

            if (productToDelete == null)
                throw new NotFoundException(nameof(ProductBrand), request.Id);

            await _productBrandService.DeleteAsync(request.Id);
        }
    }
}
