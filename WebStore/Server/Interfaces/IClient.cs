using WebStore.Shared.Models;

namespace WebStore.Server.Interfaces
{
    public interface IClient
    {
        public List<Shared.Models.Client> GetClients();

        public void AddClient(Shared.Models.Client client);

        public void UpdateClient(Shared.Models.Client client);

        public Shared.Models.Client GetClientById(int id);

        public void DeleteClient(int id);
    }
}
