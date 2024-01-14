using FlowersInYou.Models;
using FlowersInYou.Repositories;

namespace FlowersInYou.Services
{
    public interface ICourierService
    {
        IEnumerable<Courier> GetCouriersList();
        Courier GetCourier(int id);
        bool CreateCourier(Courier courier);
        bool UpdateCourier(int id, Courier courier);
        bool DeleteCourier(int id);
    }

    public class CourierService : ICourierService
    {
        private readonly ICourierRepository _courierRepository;

        public CourierService(ICourierRepository courierRepository)
        {
            _courierRepository = courierRepository;
        }

        public IEnumerable<Courier> GetCouriersList()
        {
            return _courierRepository.GetCouriersList();
        }

        public Courier GetCourier(int id)
        {
            return _courierRepository.GetCourier(id);
        }

        public bool CreateCourier(Courier courier)
        {
            return _courierRepository.CreateCourier(courier);
        }

        public bool UpdateCourier(int id, Courier courier)
        {
            return _courierRepository.UpdateCourier(id, courier);
        }

        public bool DeleteCourier(int id)
        {
            return _courierRepository.DeleteCourier(id);
        }
    }
}
