using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CineTecBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {

        private readonly cinetecContext _context;
        public ClientController(cinetecContext context)
        {
            _context = context;
        }

        // Get all clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.Clients.ToListAsync();

        }

        // Get a client by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            return await _context.Clients.FindAsync(id);

        }

        // Post a client
        [HttpPost]
        public async Task<ActionResult> Add(Client client)
        {
            var itemToAdd = await _context.Clients.FindAsync(client.Id);
            if (itemToAdd != null)
                return Conflict();
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Update a client
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateClient(int id, Client client)
        {
            var itemToUpdate = await _context.Clients.FindAsync(id);
            if (itemToUpdate == null)
                return NotFound();
            itemToUpdate.FirstName = client.FirstName;
            itemToUpdate.LastName = client.LastName;
            itemToUpdate.SecLastName = client.SecLastName;
            itemToUpdate.Age = client.Age;
            itemToUpdate.PhoneNumber = client.PhoneNumber;
            itemToUpdate.Password = client.Password;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Delete a client
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClient(int id)
        {
            var itemToRemove = await _context.Clients.FindAsync(id);

            if (itemToRemove == null)
                return NotFound();

            _context.Clients.Remove(itemToRemove);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}