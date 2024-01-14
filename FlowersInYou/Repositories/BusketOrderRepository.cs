using FlowersInYou.Models;

namespace FlowersInYou.Repositories
{
    public interface IBusketOrderRepository
    {
        IEnumerable<BusketOrder> GetBusketOrderList();
        BusketOrder GetBusketOrder(int id);
        object GetProductsInBusket(int orderId);
        bool CreateRange(IEnumerable<BusketOrder> busketOrders);
    }

    public class BusketOrderRepository : IBusketOrderRepository
    {
        private FlowersInYouContext _context;

        public BusketOrderRepository(FlowersInYouContext context)
        {
            _context = context;
        }

        public object GetProductsInBusket(int orderId) 
        {
            var productsList = _context.BusketOrder.Where(p => p.IdOrder == orderId).Select(l => new
            {
                Name = l.IdBusketNavigation.IdConfigurateProductNavigation.IdProductNavigation.Name,
                Material = l.IdBusketNavigation.IdConfigurateProductNavigation.IdMaterialNavigation.Name,
                Size = l.IdBusketNavigation.IdConfigurateProductNavigation.IdSizeNavigation.Size1,
            }).ToList();

            return productsList;
        }

        public IEnumerable<BusketOrder> GetBusketOrderList()
        {
            return _context.BusketOrder.ToList();
        }

        public BusketOrder GetBusketOrder(int id)
        {
            return _context.BusketOrder.Find(id);
        }

        public bool CreateRange(IEnumerable<BusketOrder> busketOrders)
        {
            if (busketOrders != null)
            {
                try
                {
                    _context.AddRange(busketOrders);
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
