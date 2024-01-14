using FlowersInYou.Models;

namespace FlowersInYou.Repositories
{
    public interface IConfirmedOrderRepository
    {
        IEnumerable<ConfirmedOrder> GetConfirmedOrdersList();
        ConfirmedOrder GetConfirmedOrder(int id);
        bool CreateConfirmedOrder(ConfirmedOrder confirmedOrder);
        bool UpdateConfirmedOrder(int id, ConfirmedOrder confirmedOrder);
        bool DeleteConfirmedOrder(int id);
    }

    public class ConfirmedOrderRepository : IConfirmedOrderRepository
    {
        private FlowersInYouContext _context;

        public ConfirmedOrderRepository(FlowersInYouContext context)
        {
            _context = context;
        }

        public IEnumerable<ConfirmedOrder> GetConfirmedOrdersList()
        {
            return _context.ConfirmedOrder.ToList();
        }

        public ConfirmedOrder GetConfirmedOrder(int id)
        {
            return _context.ConfirmedOrder.Find(id);
        }

        public bool CreateConfirmedOrder(ConfirmedOrder confirmedOrder)
        {
            if (confirmedOrder != null)
            {
                try
                {
                    _context.Add(confirmedOrder);
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

        public bool UpdateConfirmedOrder(int id, ConfirmedOrder confirmedOrder)
        {
            if (confirmedOrder != null)
            {
                try
                {
                    _context.ConfirmedOrder.Update(confirmedOrder);
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

        public bool DeleteConfirmedOrder(int id)
        {
            ConfirmedOrder confirmedOrder = GetConfirmedOrder(id);

            if (confirmedOrder != null)
            {
                try
                {
                    _context.ConfirmedOrder.Remove(confirmedOrder);
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
