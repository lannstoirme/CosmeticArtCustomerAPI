using System;
using CosmeticArtAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmeticArtAPI.Models;
using CosmeticArtAPI.Controllers;
using MongoDB.Driver;

namespace CosmeticArtAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("{id:length(24)}"), Name = "GetClient")]
        public ActionResult<Client> Get(string id)
        {
            var client = _clientService.Get(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        [HttpPost]
        public ActionResult<Client> Create<Client client>
        {
            _clientService.Create(client);

            return CreatedAtRoute("GetClient", new { id = client.Id.ToString() }, client);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Client clientIn)
        {
            var client = clientService.Get(id);

            if (client == null)
            {
                return NotFound();
            }

            _clientService.Update(id, clientIn);

            return NoContent();
        }

        [HttpDelete("{id: length(24)}")]
        public IActionResult Delete(string id)
        {
            var client = _clientService.Get(id);

            if (client == null)
            {
                return NotFound();
            }

            _clientService.Remove(client.Id);

            return NoContent();
        }
        }
    }
}
