using System;
using CosmeticArtAPI.Models;
using CosmeticArtAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        [HttpGet]
        public ActionResult<List<Client>> Get() =>
            _clientService.Get();

        [HttpGet("{id:length(24)}", Name = "GetClient")]
        public ActionResult<Client> Get(string id)
        {
            var book = _clientService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<Client> Create(Client client)
        {
            _clientService.Create(client);

            return CreatedAtRoute("GetClient", new { id = client.Id.ToString() }, client);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Client clientIn)
        {
            var book = _clientService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _clientService.Update(id, clientIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _clientService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _clientService.Remove(client.Id);

            return NoContent();
        }
    }
}
