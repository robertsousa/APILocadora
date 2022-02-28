using LocadoraAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraAPI.Services
{
    public interface IClienteService
    {
        Cliente AddCliente(Cliente cliente);
        Cliente FindByID(int id);
        Cliente FindByName(string name);
        //Task<<IActionResult>List<Cliente>> GetAll();
        void DeleteCliente(int id); 

    }
}
