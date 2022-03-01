using LocadoraAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace LocadoraAPI.Context
{
    public class SeedData
    {
        internal static void Initialize(IServiceProvider services)
        {
            using (var context = new LocadoraAPIContext(services.GetRequiredService<DbContextOptions<LocadoraAPIContext>>()))
            {
                if (context.Clientes.Any())
                {
                    return;
                }

                context.Clientes.AddRange(
                    new Cliente
                    {
                        ID = 1,
                        Name = "Roberto",
                        IsActive = true
                    },
                    new Cliente
                    {
                        ID = 2,
                        Name = "Michelle",
                        IsActive = true
                    },
                    new Cliente
                    {
                        ID = 3,
                        Name = "Paulo",
                        IsActive = true
                    },
                    new Cliente
                    {
                        ID = 4,
                        Name = "Sophia",
                        IsActive = false
                    },
                    new Cliente
                    {
                        ID = 5,
                        Name = "Ícaro",
                        IsActive = false
                    }

                );

                context.SaveChanges();

                context.Filmes.AddRange(
                    new Filme
                    {
                        Id = 1,
                        Title = "Matrix",
                        IsLeased = true,
                        IsActive = true
                    },
                    new Filme
                    {
                        Id = 2,
                        Title = "Homem Aranha",
                        IsLeased = false,
                        IsActive = true
                    },new Filme
                    {
                        Id = 3,
                        Title = "Eternos",
                        IsLeased = true,
                        IsActive = true
                    },
                    new Filme
                    {
                        Id = 4,
                        Title = "Rambo 5",
                        IsLeased = false,
                        IsActive = true
                    },
                    new Filme
                    {
                        Id = 5,
                        Title = "Uma linda mulher",
                        IsLeased = false,
                        IsActive = true
                    },
                    new Filme
                    {
                        Id = 6,
                        Title = "Eu e Irene",
                        IsLeased = false,
                        IsActive = true
                    },
                    new Filme
                    {
                        Id = 7,
                        Title = "O maskara",
                        IsLeased = false,
                        IsActive = true
                    },
                    new Filme
                    {
                        Id = 8,
                        Title = "O todo poderoso",
                        IsLeased = false,
                        IsActive = true
                    },
                    new Filme
                    {
                        Id = 9,
                        Title = "Detetive Virtual",
                        IsLeased = false,
                        IsActive = true
                    },
                    new Filme
                    {
                        Id = 10,
                        Title = "11 homnes e um segredo",
                        IsLeased = false,
                        IsActive = true
                    }
                 );

                context.SaveChanges();

                context.Locacaos.AddRange(
                    new Locacao
                    {
                        Id = 1,
                        IdCliente = 1,
                        IdFilme = 1,
                        DataLocacao = DateTime.Parse("2022-03-01"),
                        DataDevolucao = DateTime.Parse("2022-03-05")
                    },
                    new Locacao
                    {
                        Id = 2,
                        IdCliente = 2,
                        IdFilme = 3,
                        DataLocacao = DateTime.Parse("2022-02-20"),
                        DataDevolucao = DateTime.Parse("2022-02-25")
                    }


                );

                context.SaveChanges();
            }
        }
    }
}
