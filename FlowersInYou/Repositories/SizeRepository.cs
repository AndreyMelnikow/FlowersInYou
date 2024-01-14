using FlowersInYou.Models;

namespace FlowersInYou.Repositories
{
    public interface ISizeRepository
    {
        IEnumerable<Size> GetSizesList();
        Size GetSize(int id);
    }

    public class SizeRepository : ISizeRepository
    {
        private FlowersInYouContext _context;

        public SizeRepository(FlowersInYouContext context)
        {
            _context = context;
        }

        public IEnumerable<Size> GetSizesList()
        {
            return _context.Size.ToList();
        }

        public Size GetSize(int id)
        {
            return _context.Size.Find(id);
        }
    }
}
