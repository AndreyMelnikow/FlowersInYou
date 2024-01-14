using FlowersInYou.Models;

namespace FlowersInYou.Repositories
{
    public interface ICourierRepository
    {
        IEnumerable<Courier> GetCouriersList();
        Courier GetCourier(int id);
        Courier GetCourierByPhone(string phone);
        bool CreateCourier(Courier courier);
        bool UpdateCourier(int id, Courier courier);
        bool DeleteCourier(int id);
    }

    public class CourierRepository : ICourierRepository
    {
        private FlowersInYouContext _context;

        public CourierRepository(FlowersInYouContext context)
        {
            _context = context;
        }

        public IEnumerable<Courier> GetCouriersList()
        {
            return _context.Courier.ToList();
        }

        public Courier GetCourier(int id)
        {
            return _context.Courier.Find(id);
        }

        public Courier GetCourierByPhone(string phone)
        {
            return _context.Courier.Where(p => p.PhoneNumber == phone).FirstOrDefault();
        }

        public bool CreateCourier(Courier courier)
        {
            if (courier != null)
            {
                try
                {
                    _context.Add(courier);
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

        public bool UpdateCourier(int id, Courier courier)
        {
            if (courier != null)
            {
                try
                {
                    _context.Courier.Update(courier);
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

        public bool DeleteCourier(int id)
        {
            Courier courier = GetCourier(id);

            if (courier != null)
            {
                try
                {
                    _context.Courier.Remove(courier);
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
