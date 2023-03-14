using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class ProductItemService : BaseRepository<ProductItem>, IProductItemService
    {
        private readonly ECommerceDbContext _context;

        public ProductItemService(ECommerceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ProductItem>> GetProductByGuidArray(int[] ids)
        {
            var res = _context.ProductItems.Where(x => ids.Contains(x.Id)).ToList();

            return res;
        }

        public async Task<ProductItem> GetProductItemWithBrandAndType(int id)
        {
            var productItem = await _context.ProductItems.FirstOrDefaultAsync(x => x.Id == id);

            if(productItem != null)
            {
                var productBrand = await _context.ProductBrands.FirstOrDefaultAsync(x => x.Id == productItem.ProductBrandId);
                var productType = await _context.ProductTypes.FirstOrDefaultAsync(x => x.Id == productItem.ProductTypeId);
                productItem.AddProductBrandAndType(productBrand, productType);
            }

            return productItem;
            
        }
    }
}
