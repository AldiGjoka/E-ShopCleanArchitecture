using Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.ProductTypes.Command.UpdateProductType
{
    public record UpdateProductTypeCommand : IRequest
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }

    public class UpdateProductTypeCommandHandler : IRequestHandler<UpdateProductTypeCommand>
    {
        private readonly IProductTypeService _productTypeService;
        private readonly IMapper _mapper;
        public UpdateProductTypeCommandHandler(IProductTypeService productTypeService, IMapper mapper)
        {
            _productTypeService = productTypeService;
            _mapper = mapper;
        }

        public async Task Handle(UpdateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var productToBeUpdated = await _productTypeService.GetById(request.Id);

            if (productToBeUpdated == null)
                throw new NotFoundException(nameof(ProductType), request.Id);

            productToBeUpdated.UpdateProductType(request.Type);

            await _productTypeService.UpdateAsync(productToBeUpdated);
        }
    }
}
