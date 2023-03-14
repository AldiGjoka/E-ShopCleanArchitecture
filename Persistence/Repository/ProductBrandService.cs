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
    public class ProductBrandService : BaseRepository<ProductBrand>, IProductBrandService
    {
        private readonly ECommerceDbContext _context;
        public ProductBrandService(ECommerceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> GetProductBrandByName(string name)
        {
            var productBrand = await _context.ProductBrands.AnyAsync(x => x.Brand == name);

            return productBrand;
        }
    }
}
