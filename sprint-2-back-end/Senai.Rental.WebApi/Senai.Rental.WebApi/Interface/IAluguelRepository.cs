using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interface
{
    interface IAluguelRepository
    {
        List<AluguelDomains> ListarTodos();

        AluguelDomains BuscarPorId (int idAluguel);

        void Cadastrar(AluguelDomains novoAluguel);

        void AtualizarIdUrl(int idAluguel, AluguelDomains aluguelAtualizado);

        void Deletar(int idAluguel);
    }
}
