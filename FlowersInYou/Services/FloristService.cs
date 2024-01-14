using FlowersInYou.Models;
using FlowersInYou.Repositories;

namespace FlowersInYou.Services
{
    public interface IFloristService
    {
        IEnumerable<Florist> GetFloristsList();
        Florist GetFlorist(int id);
        bool CreateFlorist(Florist florist);
        bool UpdateFlorist(int id, Florist florist);
        bool DeleteFlorist(int id);
    }

    public class FloristService : IFloristService
    {
        private readonly IFloristRepository _floristRepository;

        public FloristService(IFloristRepository floristRepository)
        {
            _floristRepository = floristRepository;
        }

        public IEnumerable<Florist> GetFloristsList()
        {
            return _floristRepository.GetFloristList();
        }

        public Florist GetFlorist(int id)
        {
            return _floristRepository.GetFlorist(id);
        }

        public bool CreateFlorist(Florist florist)
        {
            return _floristRepository.CreateFlorist(florist);
        }

        public bool UpdateFlorist(int id, Florist florist)
        {
            return _floristRepository.UpdateFlorist(id, florist);
        }

        public bool DeleteFlorist(int id)
        {
            return _floristRepository.DeleteFlorist(id);
        }
    }
}
