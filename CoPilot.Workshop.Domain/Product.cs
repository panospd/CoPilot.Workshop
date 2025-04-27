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
            return new Product(0, name, description, price);
        }
    }
}
