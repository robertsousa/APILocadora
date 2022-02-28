using LocadoraAPI.Models;

namespace LocadoraAPI.Services
{
    public interface IClienteService
    {
        Cliente AddCliente(Cliente cliente);
        Cliente FindByID(int id);
        Cliente FindByName(string name);
        List<Cliente> GetAll();
        void DeleteCliente(int id); 

    }
}
