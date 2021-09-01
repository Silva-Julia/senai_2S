using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interface
{
    interface IVeiculosRepository
    {
        List<VeiculoDomains> ListarTodos();

        VeiculoDomains BuscarPorId(int idVeiculo);

        void Cadastrar(VeiculoDomains novoVeiculo);

        void AtualizarIdUrl(int idVeiculo, VeiculoDomains veiculoAtualizado);

        void Deletar(int idVeiculo);
    }
}
