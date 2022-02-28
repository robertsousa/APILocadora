using Microsoft.AspNetCore.Mvc;

namespace LocadoraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {        
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
        }

        [HttpGet("get-all")]
        public IActionResult GetAllCliente()
        {

            return Ok();
        }
    }
}