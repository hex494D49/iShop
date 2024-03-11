using iShop.Models;

namespace iShop.Services
{
    public interface IProductService
    {
        Product GetProductById(int id);

        IEnumerable<Product> GetAllProducts();

        void CreateProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(int id);

        int GetProductCount();
    }
}
