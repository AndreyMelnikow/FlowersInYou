using FlowersInYou.Models;
using FlowersInYou.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlowersInYou.Services
{
    public interface IConfirmedOrderService
    {
        IEnumerable<ConfirmedOrder> GetConfirmedOrderList();
        ConfirmedOrder GetConfirmedOrder(int id);
        bool CreateConfirmedOrder(ConfirmedOrder confirmedOrder, string courierPhone, string floristPhone);
        bool UpdateConfirmedOrder(int id, ConfirmedOrder confirmedOrder);
        bool DeleteConfirmedOrder(int id);
    }

    public class ConfirmedOrderService : IConfirmedOrderService
    {
        private readonly IConfirmedOrderRepository _confirmedOrderRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IZoneRepository _zoneRepository;
        private readonly ICourierRepository _courierRepository;
        private readonly IFloristRepository _floristRepository;

        public ConfirmedOrderService(IConfirmedOrderRepository confirmedOrderRepository, IOrderRepository orderRepository, 
            IZoneRepository zoneRepository, ICourierRepository courierRepository, IFloristRepository floristRepository)
        {
            _confirmedOrderRepository = confirmedOrderRepository;
            _orderRepository = orderRepository;
            _zoneRepository = zoneRepository;
            _courierRepository = courierRepository;
            _floristRepository = floristRepository;
        }

        public IEnumerable<ConfirmedOrder> GetConfirmedOrderList()
        {
            return _confirmedOrderRepository.GetConfirmedOrdersList();
        }

        public ConfirmedOrder GetConfirmedOrder(int id)
        {
            return _confirmedOrderRepository.GetConfirmedOrder(id);
        }

        public bool CreateConfirmedOrder(ConfirmedOrder confirmedOrder, string courierPhone, string floristPhone)
        {
            try
            {
                double range = _orderRepository.GetOrder(confirmedOrder.IdOrder).Range;
                confirmedOrder.IdZone = _zoneRepository.GetZoneByRange(range).Id;
                confirmedOrder.IdCourier = _courierRepository.GetCourierByPhone(courierPhone).Id;
                confirmedOrder.IdFlorist = _floristRepository.GetFloristByPhone(floristPhone).Id;

                return _confirmedOrderRepository.CreateConfirmedOrder(confirmedOrder);
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateConfirmedOrder(int id, ConfirmedOrder confirmedOrder)
        {
            return _confirmedOrderRepository.UpdateConfirmedOrder(id, confirmedOrder);
        }

        public bool DeleteConfirmedOrder(int id)
        {
            return _confirmedOrderRepository.DeleteConfirmedOrder(id);
        }
    }
}
