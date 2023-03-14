using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.BasketAggregate
{
    public class BasketItem : BaseEntity
    {
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public int ProductItemId { get; private set; }
        public int BasketId { get; private set; }

        public BasketItem(decimal unitPrice, int quantity, int productItemId)
        {
            ProductItemId = productItemId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public void AddQuantity(int quantity)
        {
            if(quantity == 0)
                Quantity = quantity;

            Quantity += quantity;
        }
    }
}
