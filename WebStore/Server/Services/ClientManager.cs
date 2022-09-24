using Microsoft.EntityFrameworkCore;
using WebStore.Server.Interfaces;
using WebStore.Shared.Models;

namespace WebStore.Server.Services
{
    public class ClientManager : IClient
    {
        private DatabaseContext _dbContext = new();

        public ClientManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddClient(Shared.Models.Client client)
        {
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
        }

        public void DeleteClient(int id)
        {
            Shared.Models.Client? client = _dbContext.Clients.Find(id);
            if (client == null)
            {
                throw new NullReferenceException("No Client for Delete");
            }

            _dbContext.Clients.Remove(client);
            _dbContext.SaveChanges();

        }

        public Shared.Models.Client GetClientById(int id)
        {
            Shared.Models.Client? client = _dbContext.Clients.Find(id);

            if (client == null)
            {
                throw new NullReferenceException("No Client for Update");
            }

            return client;
        }

        public List<Shared.Models.Client> GetClients()
        {
            return _dbContext.Clients.ToList();
        }

        public void UpdateClient(Shared.Models.Client client)
        {
            _dbContext.Entry(client).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
