using LocadoraAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAPI.Context
{
    public class LocadoraAPIContext : DbContext
    {
        public LocadoraAPIContext(DbContextOptions<LocadoraAPIContext> options) : base(options)
        {

        }

        public LocadoraAPIContext()
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Locacao> Locacaos { get; set; }
    }
}
