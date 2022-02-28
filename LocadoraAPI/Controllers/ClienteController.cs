using LocadoraAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {        
        private readonly ILogger<ClienteController> _logger;
        private IClienteService _clienteService;

        public ClienteController(ILogger<ClienteController> logger, IClienteService clienteService)
        {
            _logger = logger;
            _clienteService = clienteService;
        }

        [HttpGet("get-all")]
        public IActionResult GetAllCliente()
        {

            return Ok(_clienteService.GetAll());
        }
    }
}