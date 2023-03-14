
namespace Application.Features.Products.ProductBrands.Query
{
    public record GetProductBrandQuery : IRequest<List<ProductBrand>>
    {
    }

    public class GetProductBrandQueryHandler : IRequestHandler<GetProductBrandQuery, List<ProductBrand>>
    {
        private readonly IProductBrandService _productBrandService;
        private readonly IMapper _mapper;
        public GetProductBrandQueryHandler(IProductBrandService productBrandService, IMapper mapper)
        {
            _productBrandService = productBrandService;
            _mapper = mapper;
        }

        public async Task<List<ProductBrand>> Handle(GetProductBrandQuery request, CancellationToken cancellationToken)
        {
            var allProductBrands = (await _productBrandService.GetAllAsync()).OrderBy(x => x.Brand).ToList();
            return allProductBrands;
        }
    }
}
