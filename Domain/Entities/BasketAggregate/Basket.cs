
namespace Domain.Entities.BasketAggregate
{
    public class Basket : BaseEntity
    {
        public string BuyerId { get; private set; }

        private readonly List<BasketItem> _items = new List<BasketItem>();
        public IReadOnlyCollection<BasketItem> Items => _items.AsReadOnly();

        public int TotalItems => _items.Sum(i => i.Quantity);

        public Basket(string buyerId)
        {
            BuyerId = buyerId;
        }

        public void AddItem(int productItemId, decimal unitPrice, int quantity = 1)
        {
            if(!Items.Any(i => i.ProductItemId == productItemId))
            {
                _items.Add(new BasketItem(unitPrice, quantity, productItemId));
                return;
            }

            var existingItem = _items.First(i => i.ProductItemId == productItemId);
            existingItem.AddQuantity(quantity);
        }

        public void GetBasketItems(int productItemId, decimal unitPrice, int quantity = 1)
        {
            if (!Items.Any(i => i.ProductItemId == productItemId))
            {
                _items.Add(new BasketItem(unitPrice, quantity, productItemId));
                return;
            }
        }

        public void RemoveEmptyItems()
        {
            _items.RemoveAll(i => i.Quantity == 0);
        }

        public void RemoveAllItems()
        {
            _items.RemoveAll(it => it.BasketId == this.Id);
        }
    }
}
