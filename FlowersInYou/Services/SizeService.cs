using FlowersInYou.Models;
using FlowersInYou.Repositories;

namespace FlowersInYou.Services
{
    public interface ISizeService
    {
        IEnumerable<Size> GetSizesList();
        Size GetSize(int id);
    }

    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _sizeRepository;

        public SizeService(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public IEnumerable<Size> GetSizesList()
        {
            return _sizeRepository.GetSizesList();
        }

        public Size GetSize(int id)
        {
            return _sizeRepository.GetSize(id);
        }
    }
}
