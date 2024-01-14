using FlowersInYou.Models;
using FlowersInYou.Repositories;

namespace FlowersInYou.Services
{
    public interface IConfigurateProductService
    {
        IEnumerable<ConfigurateProduct> GetConfigurateProductsList();
        ConfigurateProduct GetConfigurateProduct(int id);
        bool CreateConfiguration(ConfigurateProduct configurateProduct, int clientId);
        bool DeleteConfiguration(int id);
    }

    public class ConfigurateProductService : IConfigurateProductService
    {
        private readonly IConfigurateProductRepository _configurateProductRepository;
        private readonly IBusketRepository _busketRepository;

        public ConfigurateProductService(IConfigurateProductRepository configurateProductRepository, IBusketRepository busketRepository)
        {
            _configurateProductRepository = configurateProductRepository;
            _busketRepository = busketRepository;
        }

        public IEnumerable<ConfigurateProduct> GetConfigurateProductsList()
        {
            return _configurateProductRepository.GetConfigurateProductsList();
        }

        public ConfigurateProduct GetConfigurateProduct(int id)
        {
            return _configurateProductRepository.GetConfigurateProduct(id);
        }

        public bool CreateConfiguration(ConfigurateProduct configurateProduct, int idClient)
        {

            bool isConfigurateProductCreate = _configurateProductRepository.CreateConfigurateProduct(configurateProduct);
            bool isBusketCreate = _busketRepository.CreateBusket(new Busket { IdClient = idClient, IdConfigurateProduct = configurateProduct.Id });
            return isConfigurateProductCreate && isBusketCreate;
        }

        public bool DeleteConfiguration(int id)
        {
            return _configurateProductRepository.DeleteConfigurateProduct(id);
        }
    }
}
