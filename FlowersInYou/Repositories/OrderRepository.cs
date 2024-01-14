
using FlowersInYou.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowersInYou.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrdersList();
        Order GetOrder(int id);
        bool CreateOrder(Order order);
        bool UpdateOrder(int id, Order order);
        bool DeleteOrder(int id);
    }
    public class OrderRepository : IOrderRepository
    {
        private FlowersInYouContext _context;

        public OrderRepository(FlowersInYouContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetOrdersList()
        {
            return _context.Order.ToList();
        }

        public Order GetOrder(int id)
        {
            return _context.Order.FirstOrDefault(p => p.Id == id);
        }

        public bool CreateOrder(Order order)
        {
            if (order != null)
            {
                try
                {
                    _context.Add(order);
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

        public bool UpdateOrder(int id, Order order)
        {
            if (order != null)
            {
                try
                {
                    _context.Order.Update(order);
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

        public bool DeleteOrder(int id)
        {
            Order order = GetOrder(id);

            if (order != null)
            {
                try
                {
                    _context.Order.Remove(order);
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
