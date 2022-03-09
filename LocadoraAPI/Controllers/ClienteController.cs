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

        //Retorna todos os clientes cadastrados
        [HttpGet("get-all")]
        public async Task<ActionResult> GetAllCliente()
        {
            var todosClientes = await _context.Clientes.AsNoTracking().ToListAsync();

            return Ok(todosClientes);
        }

        //Adiciona um novo cliente, aborta e comunica que se o cliente ja existir
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

            //Verifica se o cliente ja existe
            if ( cliente.ID == cliente.ID)
            {
                return BadRequest("O Cliente já está cadastrado. ");
            }
           
            //Novo cliente
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

        //Seleciona o cliente por ID
        [HttpGet("get-client/{id}")]
        public async Task<ActionResult> GetClientById(int id)
        {
            var client = await _context.Clientes.FindAsync(id);

            if(client == null)
            {
                return BadRequest("Cliente não encontrado.");
            }
            return Ok(client);
        }

        //Desativa um cliente por ID
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