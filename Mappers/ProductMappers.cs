using iShop.DTOs;
using iShop.Models;

namespace iShop.Mappers
{
    public class ProductMappers
    {
        public Product ToProductDto(ProductDto productDto)
        {

            var product = new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Status = productDto.Status
            };

            return product;
        }

        public ProductDto ToProduct(Product product)
        {

            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Status = product.Status
            };

            return productDto;
        }

    }
}
