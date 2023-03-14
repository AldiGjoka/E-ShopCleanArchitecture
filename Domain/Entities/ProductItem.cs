

namespace Domain.Entities
{
    public class ProductItem : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUri { get; private set; }
        public int ProductTypeId { get; private set; }
        public ProductType ProductType { get; private set; }
        public int ProductBrandId { get; set; }
        public ProductBrand ProductBrand { get; private set; }

        public ProductItem(string name, string description, decimal price, string pictureUri, int productTypeId, int productBrandId)
        {
            Name = name;
            Description = description;
            Price = price;
            PictureUri = pictureUri;
            ProductTypeId = productTypeId;
            ProductBrandId = productBrandId;
        }

        public void UpdateDetails(string name, string desctiption, decimal price)
        {
            Name = name;
            Description = desctiption;
            Price = price;
        }

        public void UpdateProductBrand(int brandId)
        {
            ProductBrandId = brandId;
        }

        public void UpdateProductType(int typeId)
        {
            ProductTypeId = typeId;
        }

        public void UpdatePictureUri(string picture)
        {
            if (string.IsNullOrEmpty(picture))
            {
                PictureUri = string.Empty;
            }

            PictureUri = picture;
        }

        public void AddProductBrandAndType(ProductBrand brand, ProductType type)
        {
            ProductType = type;
            ProductBrand = brand;
        }
        
    }
}
