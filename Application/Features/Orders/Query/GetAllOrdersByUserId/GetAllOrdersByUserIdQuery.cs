using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Query.GetAllOrdersByUserId
{
    public record GetAllOrdersByUserIdQuery : IRequest<List<OrderDto>>
    {
        public string UserId { get; set; }
    }


    public class GetAllOrdersByUserIdHandler : IRequestHandler<GetAllOrdersByUserIdQuery, List<OrderDto>>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public GetAllOrdersByUserIdHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> Handle(GetAllOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderService.GetAllOrdersByUserId(request.UserId);

            var orderDto = _mapper.Map<List<OrderDto>>(orders);

            return orderDto;
        }
    }
}
