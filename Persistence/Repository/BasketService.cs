using Application.Common.Interfaces;
using Domain.Entities.BasketAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class BasketService : BaseRepository<Basket>, IBasketService
    {
        private readonly ECommerceDbContext _context;
        public BasketService(ECommerceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Basket> GetBasketByUserId(string id)
        {
            var basket = await _context.Baskets.FirstOrDefaultAsync(x => x.BuyerId == id);

            if(basket == null)
            {
                basket = new Basket(id);
                await _context.Baskets.AddAsync(basket);
                await _context.SaveChangesAsync();
            }

            var basketItem = await _context.BasketItems.Where(x => x.BasketId == basket.Id).ToListAsync();

            foreach (var item in basketItem)
            {
                basket.GetBasketItems(item.ProductItemId, item.UnitPrice, item.Quantity);
            }

            return basket;
        }
    }
}
