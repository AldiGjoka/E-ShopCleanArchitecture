using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Baskets.Command.CreateBasket
{
    public record AddProductToBasketCommand : IRequest<Basket>
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int ProductTypeId { get; set; }
    }


    public class AddProductToBasketCommandHandler : IRequestHandler<AddProductToBasketCommand, Basket>
    {
        private readonly IBasketService _basketService;
        public AddProductToBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<Basket> Handle(AddProductToBasketCommand request, CancellationToken cancellationToken)
        {
            var userBasket = await _basketService.GetBasketByUserId(request.BuyerId);

            if(userBasket == null)
            {
                userBasket = new Basket(request.BuyerId);
                userBasket = await _basketService.CreateAsync(userBasket);
            }

            userBasket.AddItem(request.ProductTypeId, request.UnitPrice, request.Quantity);

            userBasket.RemoveEmptyItems();

            await _basketService.UpdateAsync(userBasket);
            
            return userBasket;
        }
    }
}
