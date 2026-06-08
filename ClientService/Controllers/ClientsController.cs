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

        [HttpPut("{id}")]
        public async Task<ActionResult<Client>> UpdateClient(int id, Client client)
        {
            if (id != client.ID)
            {
                return BadRequest("Client ID mismatch");
            }

            var existingClient = await _context.Clients.FindAsync(id);
            if (existingClient == null)
            {
                return NotFound();
            }

            existingClient.First_Name = client.First_Name;
            existingClient.Last_Name = client.Last_Name;
            existingClient.Email = client.Email;
            existingClient.Phone_Number = client.Phone_Number;
            existingClient.Addr1 = client.Addr1;
            existingClient.Municipality = client.Municipality;
            existingClient.Department = client.Department;
            existingClient.Occupation = client.Occupation;
            existingClient.DOB = client.DOB;
            existingClient.Updated_At = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(existingClient);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return Ok(client);
        }
    }
}