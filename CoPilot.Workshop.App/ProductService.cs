using CoPilot.Workshop.Domain;

namespace CoPilot.Workshop.App
{
    public class ProductService
    {
        public void CreateProduct(AddProductRequest productDto)
        {
            var product = Product.Create(
                productDto.Name,
                productDto.Description,
                productDto.Price
            );

            // Additional logic to save the product can be added here
        }
    }
}
