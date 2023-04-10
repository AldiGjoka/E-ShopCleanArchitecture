using Application.Features.Orders.Command.CreateOrders;
using Application.Features.Orders.Query.GetAllOrdersByUserId;
using Application.Features.Orders.Query.GetOrderById;
using Domain.Entities.OrderAggregate;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Authorize]
    public class OrderController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("user/{id}")]
        public async Task<ActionResult<List<OrderDto>>> GetAllOrders(string id)
        {
            var order = new GetAllOrdersByUserIdQuery() { UserId = id };

            var result = await _mediator.Send(order);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderDetail(int id)
        {
            var order = new GetOrderByIdQuery() { OrderId = id };

            var result = await _mediator.Send(order);

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] CreateOrdersCommand order)
        {
            var result = await _mediator.Send(order);

            return Ok(result);
        }

    }
}
