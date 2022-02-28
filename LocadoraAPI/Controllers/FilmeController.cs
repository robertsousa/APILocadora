using LocadoraAPI.Context;
using LocadoraAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly LocadoraAPIContext _context;

        public FilmeController(LocadoraAPIContext context)
        {
            _context = context;
        }


        [HttpGet("get-all")]
        public async Task<ActionResult> GetAllMovie()
        {
            var allMovies = await _context.Filmes.AsNoTracking().ToListAsync();

            return Ok(allMovies);
        }

        [HttpPost("add-movie")]
        public async Task<ActionResult> PostFilme(
            [FromServices] LocadoraAPIContext context,
            [FromBody] FilmeView filmeView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var novoFilme = new Filme
            {
                Id = filmeView.Id,
                Title = filmeView.Title,    
                IsLeased = filmeView.IsLeased
            };

            _context.Filmes.Add(novoFilme);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("get-movie/{id}")]
        public async Task<ActionResult> GetFilmeById(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);

            return Ok(filme);
        }

        [HttpDelete("del-movie/{id}")]
        public async Task<ActionResult> DeleteFilmeById(int id)
        {
            // var client = await _context.Clientes.Remove(id);

            return Ok();
        }
    }
}
