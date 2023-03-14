

namespace Application.Common.Interfaces
{
    public interface IProductBrandService : IBaseRepository<ProductBrand>
    {
        Task<bool> GetProductBrandByName(string name);
    }
}
