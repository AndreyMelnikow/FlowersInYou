using FlowersInYou.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace FlowersInYou.Repositories
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetClientsList();
        Client GetClient(int id);
        bool CreateClient(Client client);
        bool UpdateClient(int id, Client client);
        bool DeleteClient(int id);
    }

    public class ClientRepository : IClientRepository
    {
        private FlowersInYouContext _context;

        public ClientRepository(FlowersInYouContext context)
        {
            _context = context;
        }

        public IEnumerable<Client> GetClientsList()
        {
            return _context.Client.ToList();
        }

        public Client GetClient(int id)
        {
            return _context.Client.Find(id);
        }

        public bool CreateClient(Client client)
        {
            var clientData = _context.Client
                .FirstOrDefault(p => p.Email == client.Email || p.PhoneNumber == client.PhoneNumber || p.Login == client.Login);

            if (clientData == null && client != null)
            {
                try
                {
                    _context.Add(client);
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

        public bool UpdateClient(int id, Client client)
        {
            if (client != null)
            {
                try
                {
                    _context.Client.Update(client);
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

        public bool DeleteClient(int id)
        {
            Client client = GetClient(id);

            if (client != null)
            {
                try
                {
                    _context.Client.Remove(client);
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
