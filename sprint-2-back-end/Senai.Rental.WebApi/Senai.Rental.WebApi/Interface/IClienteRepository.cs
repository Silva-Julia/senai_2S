using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interface
{
    interface IClienteRepository
    {
        List<ClienteDomains> ListarTodos();

        ClienteDomains BuscarPorId(int idCliente);

        void Cadastrar(ClienteDomains novoCliente);

        void AtualizarIdUrl(int idCliente, ClienteDomains clienteAtualizado);

        void Deletar(int idCliente);
    }
}
