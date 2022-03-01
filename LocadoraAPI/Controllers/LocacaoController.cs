﻿using LocadoraAPI.Context;
using LocadoraAPI.Models;
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

        [HttpPost("add-locacao")]
        public async Task<ActionResult> PostLocacao(
            [FromServices] LocadoraAPIContext context,
            [FromBody] Locacao locacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Filme filmeLocado = await _context.Filmes.FindAsync(locacao.IdFilme);

            if (filmeLocado.IsLeased == true)
            {
                return BadRequest("O filme ja está locado. ");
            }

            if (filmeLocado != null)
            {
                filmeLocado.IsLeased = true;
            }

            var novaLocacao = new Locacao
            {
                Id = locacao.Id,
                IdCliente = locacao.IdCliente,
                IdFilme = locacao.IdFilme,
                DataLocacao = locacao.DataLocacao,
                DataDevolucao = locacao.DataDevolucao
            };

            _context.Filmes.Update(filmeLocado);
            _context.Locacaos.Add(novaLocacao);
            await _context.SaveChangesAsync();

            return Ok("Locação efetuada.");
        }

        [HttpPut("dev-locacao/{id}")]
        public async Task<ActionResult> PutDevLocacaoById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Locacao locacaoADevolver = await _context.Locacaos.FindAsync(id);

            Filme filmeLocado = await _context.Filmes.FindAsync(locacaoADevolver.IdFilme);

            if (locacaoADevolver == null)
            {
                return BadRequest("Locação não encontrada. ");
            }

            if (locacaoADevolver != null)
            {
                DateTime dataAtual = DateTime.Now;
                if(dataAtual > locacaoADevolver.DataDevolucao)
                {
                    filmeLocado.IsLeased = false;
                    _context.SaveChanges();
                    return Ok("Devolução efetuada com atraso.");
                }

                filmeLocado.IsLeased = false;
                _context.SaveChanges();
            }

            return Ok("Devolução efetuada.");
        }
    }
}
