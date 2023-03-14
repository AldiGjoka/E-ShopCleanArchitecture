using Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Baskets.Query.GetBasketById
{
    public record GetBasketByIdQuery : IRequest<Basket>
    {
        public int BasketId { get; set; }
    }


    public class GetBasketByIdCommandHandler : IRequestHandler<GetBasketByIdQuery, Basket>
    {
        private readonly IBasketService _basketService;
        public GetBasketByIdCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<Basket> Handle(GetBasketByIdQuery request, CancellationToken cancellationToken)
        {
            var basket = await _basketService.GetById(request.BasketId);

            if(basket == null)
                throw new NotFoundException(nameof(Basket), request.BasketId);

            return basket;
        }
    }
}
