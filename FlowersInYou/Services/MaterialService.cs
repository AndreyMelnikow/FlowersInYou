using FlowersInYou.Models;
using FlowersInYou.Repositories;

namespace FlowersInYou.Services
{
    public interface IMaterialService
    {
        IEnumerable<Material> GetMaterialList();
        Material GetMaterial(int id);
    }

    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public IEnumerable<Material> GetMaterialList()
        {
            return _materialRepository.GetMaterialList();
        }

        public Material GetMaterial(int id)
        {
            return _materialRepository.GetMaterial(id);
        }
    }
}
