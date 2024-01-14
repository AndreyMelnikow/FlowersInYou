using FlowersInYou.Models;

namespace FlowersInYou.Repositories
{
    public interface IFloristRepository
    {
        IEnumerable<Florist> GetFloristList();
        Florist GetFlorist(int id);
        Florist GetFloristByPhone(string phone);
        bool CreateFlorist(Florist florist);
        bool UpdateFlorist(int id, Florist florist);
        bool DeleteFlorist(int id);
    }

    public class FloristRepository : IFloristRepository
    {
        private FlowersInYouContext _context;

        public FloristRepository(FlowersInYouContext context)
        {
            _context = context;
        }

        public IEnumerable<Florist> GetFloristList()
        {
            return _context.Florist.ToList();
        }

        public Florist GetFlorist(int id)
        {
            return _context.Florist.Find(id);
        }

        public Florist GetFloristByPhone(string phone)
        {
            return _context.Florist.Where(p => p.PhoneNumber == phone).FirstOrDefault();
        }

        public bool CreateFlorist(Florist florist)
        {
            if (florist != null)
            {
                try
                {
                    _context.Add(florist);
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

        public bool UpdateFlorist(int id, Florist florist)
        {
            if (florist != null)
            {
                try
                {
                    _context.Florist.Update(florist);
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

        public bool DeleteFlorist(int id)
        {
            Florist florist = GetFlorist(id);

            if (florist != null)
            {
                try
                {
                    _context.Florist.Remove(florist);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return false;
        }
    }
}
