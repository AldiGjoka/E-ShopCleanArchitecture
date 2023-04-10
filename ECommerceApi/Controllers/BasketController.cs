using Application.Features.Baskets.Command.CreateBasket;
using Application.Features.Baskets.Query.GetBasketById;
using Application.Features.Baskets.Query.GetBasketByUserId;
using Domain.Entities.BasketAggregate;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Authorize]
    public class BasketController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<Basket>> GetBasketByUserId(string id)
        {
            var basket = new GetBasketByUserIdQuery() { UserId = id };
            var result = await _mediator.Send(basket);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Basket>> GetBasketById(int id)
        {
            var basket = new GetBasketByIdQuery() { BasketId = id };

            var result = await _mediator.Send(basket);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBasket(string id, [FromBody] AddProductToBasketCommand product)
        {
            if(id != product.BuyerId)
            {
                return BadRequest();
            }

            await _mediator.Send(product);

            return NoContent();
        }
    }
}
