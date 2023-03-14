

namespace Domain.Entities
{
    public class ProductType : BaseEntity
    {
        public string Type { get; private set; }
        public ProductType(string type)
        {
            Type = type;
        }

        public void UpdateProductType(string type)
        {
            if(!string.IsNullOrEmpty(type))
                Type = type;
        }
    }
}
