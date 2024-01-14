using FlowersInYou.Models;
using FlowersInYou.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlowersInYou.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductsList();
        Product GetProduct(int id);
        object GetProductsProductType(int idProductType);
        bool CreateProduct(Product product);
        bool UpdateProduct(int id, Product product);
        bool DeleteProduct(int id);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetProductsList()
        {
            return _productRepository.GetProductsList();
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetProduct(id);
        }

        public object GetProductsProductType(int idProductType)
        {
            var product = _productRepository.GetProductsList().Where(p => p.IdProductType == idProductType)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Photo,
                    p.ShortDescription,
                    p.StartPrice
                }).ToList();

            return product;
        }

        public bool CreateProduct(Product product)
        {
            return _productRepository.CreateProduct(product);
        }

        public bool UpdateProduct(int id, Product product)
        {
            return _productRepository.UpdateProduct(id, product);
        }

        public bool DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }
    }
}
