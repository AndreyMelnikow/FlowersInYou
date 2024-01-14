using FlowersInYou.Models;

namespace FlowersInYou.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProductsList();
        Product GetProduct(int id);
        bool CreateProduct(Product product);
        bool UpdateProduct(int id, Product product);
        bool DeleteProduct(int id);
    }

    public class ProductRepository : IProductRepository
    {
        private FlowersInYouContext _context;

        public ProductRepository(FlowersInYouContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProductsList()
        {
            return _context.Product.ToList();
        }

        public Product GetProduct(int id)
        {
            return _context.Product.Find(id);
        }

        public bool CreateProduct(Product product)
        {
            if (product != null)
            {
                try
                {
                    _context.Add(product);
                    _context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }

        public bool UpdateProduct(int id, Product product)
        {
            if (product != null)
            {
                try
                {
                    _context.Product.Update(product);
                    _context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }

        public bool DeleteProduct(int id)
        {
            Product product = GetProduct(id);

            if (product != null)
            {
                try
                {
                    _context.Product.Remove(product);
                    _context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }
    }
}
