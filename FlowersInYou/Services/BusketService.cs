using FlowersInYou.Models;
using FlowersInYou.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlowersInYou.Services
{
    public interface IBusketService
    {
        IEnumerable<Busket> GetBusketList();
        decimal GetFullAmount(int clientId);
    }

    public class BusketService : IBusketService
    {
        private readonly IBusketRepository _busketRepository;

        public BusketService(IBusketRepository busketRepository)
        {
            _busketRepository = busketRepository;
        }

        public IEnumerable<Busket> GetBusketList()
        {
            return _busketRepository.GetBusketList();
        }

        public decimal GetFullAmount(int clientId) 
        {
            return GetFullAmount(clientId);
        }
    }
}
