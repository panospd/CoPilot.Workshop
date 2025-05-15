// CoPilot.Workshop.Domain/Product.cs

namespace CoPilot.Workshop.Domain
{
    
    public class Product : BaseEntity
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 50;
        public const int DescriptionMinLength = 3;
        public const int DescriptionMaxLength = 200;
        public const decimal PriceMinValue = 0.01m;

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
            if (string.IsNullOrWhiteSpace(name) || name.Length < NameMinLength || name.Length > NameMaxLength)
                throw new ArgumentException($"Name must be between {NameMinLength} and {NameMaxLength} characters.", nameof(name));

            if (string.IsNullOrWhiteSpace(description) || description.Length < DescriptionMinLength || description.Length > DescriptionMaxLength)
                throw new ArgumentException($"Description must be between {DescriptionMinLength} and {DescriptionMaxLength} characters.", nameof(description));

            if (price < PriceMinValue)
                throw new ArgumentOutOfRangeException(nameof(price), $"Price must be greater than or equal to {PriceMinValue}.");

            return new Product(0, name, description, price);
        }
    }
}
