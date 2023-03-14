using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderAggregate
{
    public class ProductItemOrdered
    {
        public int ProductItemId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUri { get; private set; }

        public ProductItemOrdered(int productItemId, string productName, string pictureUri)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            PictureUri = pictureUri;
        }


        // Required by Ef Core
        private ProductItemOrdered() { }
    }
}
