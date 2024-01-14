using FlowersInYou.Models;

namespace FlowersInYou.Repositories
{
    public interface IZoneRepository
    {
        IEnumerable<Zone> GetZonesList();
        Zone GetZone(int id);
        Zone GetZoneByRange(double range);
    }

    public class ZoneRepository : IZoneRepository
    {
        private FlowersInYouContext _context;

        public ZoneRepository(FlowersInYouContext context)
        {
            _context = context;
        }

        public IEnumerable<Zone> GetZonesList()
        {
            return _context.Zone.ToList();
        }

        public Zone GetZone(int id)
        {
            return _context.Zone.Find(id);
        }

        public Zone GetZoneByRange(double range)
        {
            return _context.Zone.FirstOrDefault(p => p.MinRange <= range && p.MaxRange >= range);
        }
    }
}
