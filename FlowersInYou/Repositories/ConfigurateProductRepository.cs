using FlowersInYou.Models;

namespace FlowersInYou.Repositories
{
    public interface IConfigurateProductRepository
    {
        IEnumerable<ConfigurateProduct> GetConfigurateProductsList();
        ConfigurateProduct GetConfigurateProduct(int id);
        bool CreateConfigurateProduct(ConfigurateProduct configurateProduct);
        bool UpdateConfigurateProduct(int id, ConfigurateProduct configurateProduct);
        bool DeleteConfigurateProduct(int id);
    }

    public class ConfigurateProductRepository : IConfigurateProductRepository
    {
        private FlowersInYouContext _context;

        public ConfigurateProductRepository(FlowersInYouContext context)
        {
            _context = context;
        }

        public IEnumerable<ConfigurateProduct> GetConfigurateProductsList()
        {
            return _context.ConfigurateProduct.ToList();
        }

        public ConfigurateProduct GetConfigurateProduct(int id)
        {
            return _context.ConfigurateProduct.Find(id);
        }

        public bool CreateConfigurateProduct(ConfigurateProduct configurateProduct)
        {
            if (configurateProduct != null)
            {
                try
                {
                    _context.Add(configurateProduct);
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

        public bool UpdateConfigurateProduct(int id, ConfigurateProduct configurateProduct)
        {
            if (configurateProduct != null)
            {
                try
                {
                    _context.ConfigurateProduct.Update(configurateProduct);
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

        public bool DeleteConfigurateProduct(int id)
        {
            ConfigurateProduct configurateProduct = GetConfigurateProduct(id);

            if (configurateProduct != null)
            {
                try
                {
                    _context.ConfigurateProduct.Remove(configurateProduct);
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
