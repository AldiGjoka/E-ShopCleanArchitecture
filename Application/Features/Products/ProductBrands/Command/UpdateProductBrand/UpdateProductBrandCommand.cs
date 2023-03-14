using Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.ProductBrands.Command.UpdateProductBrand
{
    public record UpdateProductBrandCommand : IRequest
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
    }


    public class UpdateProductBrandCommandHandler : IRequestHandler<UpdateProductBrandCommand>
    {
        private readonly IProductBrandService _productBrandService;
        private readonly IMapper _mapper;
        public UpdateProductBrandCommandHandler(IProductBrandService productBrandService, IMapper mapper)
        {
            _productBrandService = productBrandService;
            _mapper = mapper;
        }

        public async Task Handle(UpdateProductBrandCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _productBrandService.GetById(request.Id);

            if(productToUpdate == null)
                throw new NotFoundException(nameof(ProductBrand), request.Id);

            productToUpdate.UpdateBrand(request.BrandName);

            await _productBrandService.UpdateAsync(productToUpdate);
        }
    }
}
