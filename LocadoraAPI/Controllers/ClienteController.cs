using LocadoraAPI.Context;
using LocadoraAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly LocadoraAPIContext _context;

        public ClienteController(LocadoraAPIContext context)
        {
            _context = context; 
        }

        [HttpGet("get-all")]
        public async Task<ActionResult> GetAllCliente()
        {
            var todosClientes = await _context.Clientes.AsNoTracking().ToListAsync();

            return Ok(todosClientes);
        }

        [HttpPost("add-client")]
        public async Task<ActionResult> PostClient(
            [FromServices] LocadoraAPIContext context, 
            [FromBody] ClienteView clienteView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Cliente cliente = await context.Clientes.FindAsync(clienteView.ID);

            if (cliente == null || cliente.ID == cliente.ID)
            {
                return BadRequest("O Cliente já está cadastrado. ");
            }
           
            var newCliente = new Cliente
            {
                ID = clienteView.ID,
                Name = clienteView.Name,
                IsActive = clienteView.IsActive
            };

            _context.Clientes.Add(newCliente);
            await _context.SaveChangesAsync();

            return Ok("Cliente adicionado...");
        }

        [HttpGet("get-client/{id}")]
        public async Task<ActionResult> GetClientById(int id)
        {
            var client = await _context.Clientes.FindAsync(id);

            return Ok(client);
        }

        [HttpDelete("del-client/{id}")]
        public async Task<ActionResult> DeleteClientById(int id)
        {
            Cliente clienteARemover = await _context.Clientes.FindAsync(id);

            if (clienteARemover.IsActive == false)
            {
                return Ok("O Cliente já está desativado. ");
            }

            if (clienteARemover != null)
            {
                clienteARemover.IsActive = false;
                await _context.SaveChangesAsync();
            }

            return Ok("Cliente desativado.");
        }
    }
}