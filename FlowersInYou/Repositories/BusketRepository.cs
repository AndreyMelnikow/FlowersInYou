using FlowersInYou.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowersInYou.Repositories
{
    public interface IBusketRepository
    {
        IEnumerable<Busket> GetBusketList();
        Busket GetBusket(int id);
        bool CreateBusket(Busket busket);
        decimal GetFullAmount(int clientId);
    }

    public class BusketRepository : IBusketRepository
    {
        private FlowersInYouContext _context;
        public BusketRepository(FlowersInYouContext context)
        {
            _context = context;
        }

        public IEnumerable<Busket> GetBusketList()
        {
            return _context.Busket.ToList();
        }

        public Busket GetBusket(int id)
        {
            return _context.Busket.Find(id);
        }

        public decimal GetFullAmount(int clientId)
        {
            return _context.Busket.Where(p => p.IdClient == clientId).Sum(p => p.IdConfigurateProductNavigation.Price);
        }

        public bool CreateBusket(Busket busket)
        {
            if (busket != null)
            {
                try
                {
                    _context.Add(busket);
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
