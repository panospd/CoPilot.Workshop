// CoPilot.Workshop.Domain/Product.cs

namespace CoPilot.Workshop.Domain
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        private Product(int id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public static Product Create(string name, string description, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Product name cannot be null or empty.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Product description cannot be null or empty.", nameof(description));
            }

            if (price <= 0)
            {
                throw new ArgumentException("Product price must be greater than zero.", nameof(price));
            }

            return new Product(0, name, description, price);
        }
    }
}
