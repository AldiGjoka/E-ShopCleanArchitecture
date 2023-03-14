using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IProductItemService : IBaseRepository<ProductItem>
    {
        Task<List<ProductItem>> GetProductByGuidArray(int[] ids);
        Task<ProductItem> GetProductItemWithBrandAndType(int id);
    }
}
