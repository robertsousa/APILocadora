using LocadoraAPI.Context;
using LocadoraAPI.Services;
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
        public async Task<IActionResult> GetAllCliente()
        {
            var todosClientes = await _context.Clientes.AsNoTracking().ToListAsync();

            return Ok(todosClientes);
        }
    }
}