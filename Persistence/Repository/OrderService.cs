using Application.Common.Interfaces;
using Domain.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class OrderService : BaseRepository<Order>, IOrderService
    {
        private readonly ECommerceDbContext _context;
        public OrderService(ECommerceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllOrdersByUserId(string userId)
        {
            var orders = await _context.Orders.Where(x => x.BuyerId == userId).ToListAsync();

            return orders;
        }

        public async Task<Order> GetOrderByIdWithItems(int id)
        {
            var order = await _context.Orders.Include(i => i.OrderItems).FirstOrDefaultAsync(x => x.Id == id);
            return order;
        }
    }
}
