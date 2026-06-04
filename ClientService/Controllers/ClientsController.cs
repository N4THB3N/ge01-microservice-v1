using System;
using ClientService.Data;
using ClientService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClientsController: ControllerBase
    {
        private readonly ClientContext _context;

        public ClientsController(ClientContext clientContext)
        {
            _context = clientContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient(Client client)
        {
            client.Created_At = DateTime.UtcNow;
            client.Updated_At = DateTime.UtcNow;
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClients), new { id = client.ID }, client);
        }
    }
}