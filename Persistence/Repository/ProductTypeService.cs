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
    public class ProductTypeService : BaseRepository<ProductType>, IProductTypeService
    {
        private readonly ECommerceDbContext _context;
        public ProductTypeService(ECommerceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> GetProductTypeByName(string name)
        {
            var productType = await _context.ProductTypes.AnyAsync(x => x.Type == name);

            return productType;
        }
    }
}
