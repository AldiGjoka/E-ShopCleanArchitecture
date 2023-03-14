using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderAggregate
{
    public class OrderItem : BaseEntity
    {
        public ProductItemOrdered ItemOrdered { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Units { get; private set; }

        public OrderItem(ProductItemOrdered itemOrdered, decimal unitPrice, int units)
        {
            ItemOrdered = itemOrdered;
            UnitPrice = unitPrice;
            Units = units;
        }

        // Required by Ef Core
        private OrderItem() { }
    }
}
