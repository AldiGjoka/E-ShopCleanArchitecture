using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class ProductTypeService : BaseRepository<ProductType>, IProductTypeService
    {
        public ProductTypeService(ECommerceDbContext context) : base(context)
        {
        }
    }
}
