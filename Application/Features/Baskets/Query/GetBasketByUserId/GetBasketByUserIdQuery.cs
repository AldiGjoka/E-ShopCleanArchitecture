using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Baskets.Query.GetBasketByUserId
{
    public record GetBasketByUserIdQuery : IRequest<Basket>
    {
        public string UserId { get; set; }
    }


    public class GetBasketByUserIdQueryHandler : IRequestHandler<GetBasketByUserIdQuery, Basket>
    {
        private readonly IBasketService _basketService;
        public GetBasketByUserIdQueryHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<Basket> Handle(GetBasketByUserIdQuery request, CancellationToken cancellationToken)
        {
            var basket = await _basketService.GetBasketByUserId(request.UserId);

            if (basket == null)
            {
                basket = new Basket(request.UserId);
                basket = await _basketService.CreateAsync(basket);
            }

            return basket;
        }
    }
}
