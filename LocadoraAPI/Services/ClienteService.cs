using LocadoraAPI.Context;
using LocadoraAPI.Models;

namespace LocadoraAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly LocadoraAPIContext _locadoraAPIContext;
        public ClienteService(LocadoraAPIContext locadoraAPIContext)
        {
            _locadoraAPIContext = locadoraAPIContext;
        }

        public Cliente AddCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void DeleteCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> GetAll()
        {
            var allCliente = _locadoraAPIContext.Clientes.ToList();
            return allCliente;
        }
    }
}
