using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using WebStore.Server.Interfaces;

namespace WebStore.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {


        private readonly IClient _client;

        public ClientController(IClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<List<Shared.Models.Client>> Get()
        {
            return await Task.FromResult(_client.GetClients());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Shared.Models.Client client = _client.GetClientById(id);
            if (client == null)
            {
                throw new ArgumentNullException("No client");
            }

            return Ok(client);
        }

        [HttpPost]
        public void Post(Shared.Models.Client client)
        {
            _client.AddClient(client);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _client.DeleteClient(id);
            return Ok();
        }
    }
}
