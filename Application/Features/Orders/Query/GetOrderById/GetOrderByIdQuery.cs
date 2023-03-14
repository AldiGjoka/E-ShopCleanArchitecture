using Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Query.GetOrderById
{
    public record GetOrderByIdQuery : IRequest<Order>
    {
        public int OrderId { get; set; }
    }


    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IOrderService _orderService;
        public GetOrderByIdQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetOrderByIdWithItems(request.OrderId);

            if (order == null)
                throw new NotFoundException(nameof(Order), request.OrderId);

            return order;
        }
    }
}
