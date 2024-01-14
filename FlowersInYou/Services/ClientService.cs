using FlowersInYou.Models;
using FlowersInYou.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlowersInYou.Services
{
    public interface IClientService
    {
        IEnumerable<Client> GetClientsList();
        Client GetClient(int id);
        IEnumerable<Busket> GetClientBusket(int id);
        bool CreateClient(Client client);
        bool UpdateClient(int id, Client client);
        bool DeleteClient(int id);
    }

    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IBusketRepository _busketRepository;

        public ClientService(IClientRepository clientRepository, IBusketRepository busketRepository) 
        {
            _clientRepository = clientRepository;
            _busketRepository = busketRepository;
        }

        public IEnumerable<Client> GetClientsList()
        {
            return _clientRepository.GetClientsList();
        }

        public Client GetClient(int id)
        {
            return _clientRepository.GetClient(id);
        }

        public IEnumerable<Busket> GetClientBusket(int clientId)
        {
            IEnumerable<Busket> clientBusket = _busketRepository.GetBusketList().Where(p => p.IdClient == clientId).ToList();
            return clientBusket;
        }

        public bool CreateClient(Client client)
        {
            return _clientRepository.CreateClient(client);
        }

        public bool UpdateClient(int id, Client client)
        {
            return _clientRepository.UpdateClient(id, client);
        }

        public bool DeleteClient(int id)
        {
            return _clientRepository.DeleteClient(id);
        }
    }
}
