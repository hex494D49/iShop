using iShop.Models;
using iShop.Repositories;

namespace iShop.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public void CreateProduct(Product product)
        {
            _productRepository.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            var productToDelete = _productRepository.GetById(id);
            if (productToDelete != null)
            {
                _productRepository.Delete(productToDelete);
            }
        }

        public int GetProductCount()
        {
            return _productRepository.GetCount();
        }

    }


}
