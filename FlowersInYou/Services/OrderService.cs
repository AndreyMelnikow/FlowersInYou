using FlowersInYou.Models;
using FlowersInYou.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlowersInYou.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrdersList();
        Order GetOrder(int id);
        IEnumerable<Order> GetUnacceptedOrders();
        int GetOrdersCount();
        object GetUnacceptedOrderInfo();
        bool CreateOrder(Order order, int clientId);
        bool UpdateOrder(int id, Order order);
        bool DeleteOrder(int id);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBusketOrderRepository _busketOrderRepository;
        private readonly ICourierRepository _courierRepository;
        private readonly IFloristRepository _floristRepository;
        private readonly IBusketRepository _busketRepository;

        public OrderService(IOrderRepository orderRepository, IBusketOrderRepository busketOrderRepository, 
            ICourierRepository courierRepository, IFloristRepository floristRepository, IBusketRepository busketRepository)
        {
            _orderRepository = orderRepository;
            _busketOrderRepository = busketOrderRepository;
            _courierRepository = courierRepository;
            _floristRepository = floristRepository;
            _busketRepository = busketRepository;
        }

        public IEnumerable<Order> GetOrdersList()
        {
            return _orderRepository.GetOrdersList();
        }

        public Order GetOrder(int id)
        {
            return _orderRepository.GetOrder(id);
        }

        public IEnumerable<Order> GetUnacceptedOrders() 
        {
            return _orderRepository.GetOrdersList().Where(p => !p.IsAccepted).ToList();
        }

        public int GetOrdersCount() 
        {
            return _orderRepository.GetOrdersList().Count();
        }
        public object GetUnacceptedOrderInfo()
        {
            var order = _orderRepository.GetOrdersList().Where(p => !p.IsAccepted).Select(p => new
            {
                Id = p.Id,
                Address = p.Address,
                Products = _busketOrderRepository.GetProductsInBusket(p.Id),
                Courier = _courierRepository.GetCouriersList().FirstOrDefault(p => p.IsActive && p.ConfirmedOrder
                .FirstOrDefault(l => l.IdCourier == p.Id && !l.IdOrderNavigation.IsAccepted) == null).PhoneNumber,
                Florist = _floristRepository.GetFloristList().FirstOrDefault(p => p.IsActive && p.ConfirmedOrder
                .FirstOrDefault(l => l.IdFlorist == p.Id && !l.IdOrderNavigation.IsAccepted) == null).PhoneNumber,
                IsPaid = p.IsPaid
            }).FirstOrDefault();

            return order;
        }

        public bool CreateOrder(Order order, int clientId)
        {
            var busketOrders = new List<BusketOrder>();
            var buskets = _busketRepository.GetBusketList().Where(p => p.IdClient == clientId).ToList();

            order.Price = _busketRepository.GetFullAmount(clientId);

            bool isOrderCreate = _orderRepository.CreateOrder(order);

            for (int i = 0; i < buskets.Count; i++)
            {
                busketOrders.Add(new BusketOrder
                {
                    IdBuscket = buskets[i].Id,
                    IdOrder = order.Id,
                });
            }

            bool isBusketOrderCreate = _busketOrderRepository.CreateRange(busketOrders);

            return isOrderCreate && isBusketOrderCreate;
        }

        public bool UpdateOrder(int id, Order order)
        {
            return _orderRepository.UpdateOrder(id, order);
        }

        public bool DeleteOrder(int id)
        {
            return _orderRepository.DeleteOrder(id);
        }
    }
}
