using Repository.Contexts;
using Repository.Models;
using Repository.Repositories;

namespace Service
{
    public class ClienteService
    {
        private ClienteRepository clienteRepository;

        public ClienteService(ContextoAplicacionDB contexto)
        {
            clienteRepository = new ClienteRepository(contexto);
        }

        public string insertarCliente(ClienteModel cliente)
        {
            return clienteRepository.add(cliente);
        }

        public string modificarCliente(ClienteModel cliente, int id)
        {
            if (clienteRepository.get(id) != null)
                return clienteRepository.update(cliente, id);
            else
                return "No se encontraron los datos de este cliente";
        }
        public string remove(int id)
        {
            return clienteRepository.remove(id);
        }

        public ClienteModel consultarCliente(int id)
        {
            return clienteRepository.get(id);
        }

        public IEnumerable<ClienteModel> list()
        {
            return clienteRepository.list();
        }

        public bool validarDocumentoCliente(string documento)
        {
            return clienteRepository.verificarDocumento(documento);
        }
    }
}
