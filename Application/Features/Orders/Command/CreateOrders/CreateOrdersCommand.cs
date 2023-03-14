using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Command.CreateOrders
{
    public record CreateOrdersCommand : IRequest<bool>
    {
        public string BuyerId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }


    public class CreateOrdersCommandHandler : IRequestHandler<CreateOrdersCommand, bool>
    {
        private readonly IOrderService _orderService;
        private readonly IBasketService _basketService;
        private readonly IProductItemService _productItemService;
        public CreateOrdersCommandHandler(IOrderService orderService, IBasketService basketService, IProductItemService productItemService)
        {
            _orderService = orderService;
            _basketService = basketService;
            _productItemService = productItemService;
        }

        public async Task<bool> Handle(CreateOrdersCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(request.Street, request.City, request.State, request.Country, request.ZipCode);

            var basket = await _basketService.GetBasketByUserId(request.BuyerId);

            var productIds = basket.Items.Select(item => item.ProductItemId).ToArray();

            var products = await _productItemService.GetProductByGuidArray(productIds);

            var items = basket.Items.Select(basketItem =>
            {
                var productItem = products.First(p => p.Id == basketItem.ProductItemId);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUri);
                var orderItem = new OrderItem(itemOrdered, basketItem.UnitPrice, basketItem.Quantity);
                return orderItem;
            }).ToList();

            var order = new Order(request.BuyerId, address, items);

            var res = await _orderService.CreateAsync(order);

            if(res != null)
            {
                basket.RemoveAllItems();

                await _basketService.UpdateAsync(basket);
            }
            
            return res != null ? true : false;
        }
    }
}
