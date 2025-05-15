// File: Tests/CoPilot.Workshop.Domain.Tests/ProductTests.cs
namespace CoPilot.Workshop.Domain.Tests
{
    [TestFixture]
    public class ProductTests
    {
        // --- Valid Input ---
        [Test]
        public void Create_ValidInput_ReturnsProduct()
        {
            var name = new string('a', Product.NameMinLength);
            var description = new string('b', Product.DescriptionMinLength);
            var price = Product.PriceMinValue;

            var product = Product.Create(name, description, price);

            Assert.That(product, Is.Not.Null);
            Assert.That(product.Name, Is.EqualTo(name));
            Assert.That(product.Description, Is.EqualTo(description));
            Assert.That(product.Price, Is.EqualTo(price));
        }

        // --- Name: Too Short ---
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("ab")] // 2 chars, less than min
        public void Create_NameTooShort_ThrowsArgumentException(string tooShortName)
        {
            var description = new string('d', Product.DescriptionMinLength);
            var price = Product.PriceMinValue;

            var ex = Assert.Throws<ArgumentException>(() =>
                Product.Create(tooShortName, description, price));
            Assert.That(ex.ParamName, Is.EqualTo("name"));
        }

        // --- Name: Too Long ---
        [Test]
        public void Create_NameTooLong_ThrowsArgumentException()
        {
            var tooLongName = new string('n', Product.NameMaxLength + 1);
            var description = new string('d', Product.DescriptionMinLength);
            var price = Product.PriceMinValue;

            var ex = Assert.Throws<ArgumentException>(() =>
                Product.Create(tooLongName, description, price));
            Assert.That(ex.ParamName, Is.EqualTo("name"));
        }

        // --- Description: Too Short ---
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("ab")] // 2 chars, less than min
        public void Create_DescriptionTooShort_ThrowsArgumentException(string tooShortDescription)
        {
            var name = new string('n', Product.NameMinLength);
            var price = Product.PriceMinValue;

            var ex = Assert.Throws<ArgumentException>(() =>
                Product.Create(name, tooShortDescription, price));
            Assert.That(ex.ParamName, Is.EqualTo("description"));
        }

        // --- Description: Too Long ---
        [Test]
        public void Create_DescriptionTooLong_ThrowsArgumentException()
        {
            var name = new string('n', Product.NameMinLength);
            var tooLongDescription = new string('d', Product.DescriptionMaxLength + 1);
            var price = Product.PriceMinValue;

            var ex = Assert.Throws<ArgumentException>(() =>
                Product.Create(name, tooLongDescription, price));
            Assert.That(ex.ParamName, Is.EqualTo("description"));
        }

        // --- Price: Invalid (zero, negative, less than min) ---
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(0.009)]
        public void Create_InvalidPrice_ThrowsArgumentOutOfRangeException(decimal invalidPrice)
        {
            var name = new string('a', Product.NameMinLength);
            var description = new string('b', Product.DescriptionMinLength);

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
                Product.Create(name, description, invalidPrice));
            Assert.That(ex.ParamName, Is.EqualTo("price"));
        }
    }
}
