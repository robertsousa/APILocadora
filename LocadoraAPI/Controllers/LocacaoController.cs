using LocadoraAPI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocacaoController : ControllerBase
    {
        private readonly LocadoraAPIContext _context;

        public LocacaoController(LocadoraAPIContext context)
        {
            _context = context;
        }


        [HttpGet("get-all")]
        public async Task<ActionResult> GetAllLocation()
        {
            var allMovies = await _context.Locacaos.AsNoTracking().ToListAsync();

            return Ok(allMovies);
        }
    }
}
