using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Query.GetAllOrdersByUserId
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateTimeOffset Date { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
    }
}
