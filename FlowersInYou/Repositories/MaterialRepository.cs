using FlowersInYou.Models;

namespace FlowersInYou.Repositories
{
    public interface IMaterialRepository
    {
        IEnumerable<Material> GetMaterialList();
        Material GetMaterial(int id);
    }

    public class MaterialRepository : IMaterialRepository
    {
        private FlowersInYouContext _context;

        public MaterialRepository(FlowersInYouContext context)
        {
            _context = context;
        }

        public IEnumerable<Material> GetMaterialList()
        {
            return _context.Material.ToList();
        }

        public Material GetMaterial(int id)
        {
            return _context.Material.Find(id);
        }
    }
}
