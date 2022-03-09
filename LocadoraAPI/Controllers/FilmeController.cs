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

        //Retorna todos os filmes
        [HttpGet("get-all")]
        public async Task<ActionResult> GetAllMovie()
        {
            var allMovies = await _context.Filmes.AsNoTracking().ToListAsync();

            return Ok(allMovies);
        }

        //Adiciona um novo filme 
        [HttpPost("add-movie")]
        public async Task<ActionResult> PostFilme(
            [FromServices] LocadoraAPIContext context,
            [FromBody] FilmeView filmeView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //Novo filme
            var novoFilme = new Filme
            {
                Id = filmeView.Id,
                Title = filmeView.Title,    
                IsLeased = filmeView.IsLeased,
                IsActive = filmeView.IsActive
            };

            _context.Filmes.Add(novoFilme);
            await _context.SaveChangesAsync();

            return Ok();
        }

        //Retorna um filme por ID
        [HttpGet("get-movie/{id}")]
        public async Task<ActionResult> GetFilmeById(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);

            if(filme == null)
                return NotFound();

            return Ok(filme);
        }

        //Destiva um filme por Id
        [HttpDelete("del-movie/{id}")]
        public async Task<ActionResult> DeleteFilmeById(int id)
        {
            Filme filmeARemover = await _context.Filmes.FindAsync(id);

            if (filmeARemover.IsLeased == true)
            {
                return Ok("O Filme está alugado. ");
            }

            if (filmeARemover != null)
            {
                filmeARemover.IsActive = false;
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
