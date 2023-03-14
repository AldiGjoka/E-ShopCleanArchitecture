using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductBrand : BaseEntity
    {
        public string Brand { get; private set; }

        public ProductBrand(string brand)
        {
            Brand = brand;
        }


        public void UpdateBrand(string newBrand)
        {
            Brand = newBrand;
        }
    }
}
