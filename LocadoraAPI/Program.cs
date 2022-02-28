using LocadoraAPI.Context;
using LocadoraAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<LocadoraAPIContext>(options =>
    options.UseInMemoryDatabase("Clientes"));

builder.Services.AddDbContext<LocadoraAPIContext>(options =>
    options.UseInMemoryDatabase("Filmes"));

builder.Services.AddDbContext<LocadoraAPIContext>(options =>
    options.UseInMemoryDatabase("Locacao"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
