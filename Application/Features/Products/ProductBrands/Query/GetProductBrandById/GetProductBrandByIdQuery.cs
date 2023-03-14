using Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.ProductBrands.Query.GetProductBrandById
{
    public record GetProductBrandByIdQuery : IRequest<ProductBrand>
    {
        public int BrandId { get; set; }
    }

    public class GetProductBrandByIdQueryHandler : IRequestHandler<GetProductBrandByIdQuery, ProductBrand>
    {
        private readonly IProductBrandService _productBrandService;
        private readonly IMapper _mapper;
        public GetProductBrandByIdQueryHandler(IProductBrandService productBrandService, IMapper mapper)
        {
            _productBrandService = productBrandService;
            _mapper = mapper;
        }

        public async Task<ProductBrand> Handle(GetProductBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var productBrandFormDb = await _productBrandService.GetById(request.BrandId);

            if (productBrandFormDb == null)
                throw new NotFoundException(nameof(ProductBrand), request.BrandId);

            return productBrandFormDb;
        }
    }
}
