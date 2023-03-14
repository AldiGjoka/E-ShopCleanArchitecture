using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderAggregate
{
    public class Order : BaseEntity
    {
        public string BuyerId { get; private set; }
        public DateTimeOffset OrderDate { get; private set; } = DateTimeOffset.Now;
        public Address ShipToAddress { get; private set; }
        private List<OrderItem> _orderItems = new List<OrderItem>();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public decimal Total()
        {
            var total = 0m;

            foreach (var item in _orderItems)
            {
                total += item.UnitPrice * item.Units;
            }

            return total;
        }


        public Order(string buyerId, Address shipToAddress, List<OrderItem> orderItem)
        {
            BuyerId = buyerId;
            ShipToAddress = shipToAddress;
            _orderItems = orderItem;
        }

        // Required by Ef Core
        private Order() { }
    }
}
