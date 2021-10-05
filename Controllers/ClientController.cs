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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.Clients.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            return await _context.Clients.FindAsync(id);

        }

        [HttpPost]
        public async Task<ActionResult> Add(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}