using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositores
{
    public class VeiculoRepository : IVeiculosRepository
    {
        private string stringConexao = "Data Source=NOTE0113G5\\SQLEXPRESS; initial catalog=T_Rental_Julia; user Id=sa; pwd=Senai@132";

        public void AtualizarIdUrl(int idVeiculo, VeiculoDomains veiculoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE VEICULO SET nomeCliente = @nomeCliente WHERE idCliente = @idCliente";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", clienteAtualizado.nomeCliente);
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", clienteAtualizado.sobrenomeCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public VeiculoDomains BuscarPorId(int idVeiculo)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(VeiculoDomains novoVeiculo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idVeiculo)
        {
            throw new NotImplementedException();
        }

        public List<VeiculoDomains> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}