using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                string queryUpdateUrl = "UPDATE VEICULO SET = @placa WHERE idVeiculo = @idVeiculo";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);
                    cmd.Parameters.AddWithValue("@idModelo", veiculoAtualizado.Modelo);
                    cmd.Parameters.AddWithValue("@idEmpresa", veiculoAtualizado.Empresa);
                    cmd.Parameters.AddWithValue("@placa", veiculoAtualizado.placa);
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public VeiculoDomains BuscarPorId(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idVeiculo, idModelo, idEmpresa, placa FROM VEICULO WHERE idVeiculo = @idVeiculo";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        VeiculoDomains veiculoBuscado = new VeiculoDomains()
                        {
                            idVeiculo = Convert.ToInt32(reader["idVeiculo"]),

                            Modelo = new ModeloDomains()
                            {
                                idModelo = Convert.ToInt32(reader["Modelo"]),                               
                            },                        

                            Empresa = new EmpresaDomains()
                            {
                               idEmpresa = Convert.ToInt32(reader["Empresa"])
                            },
                    
                            placa = reader["placa"].ToString()     
                            
                         };
                        return veiculoBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(VeiculoDomains novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO VEICULO (idVeiculo, idModelo, idEmpresa, placa ) VALUES (@idVeiculo)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", novoVeiculo.idVeiculo);
                    cmd.Parameters.AddWithValue("@idModelo", novoVeiculo.Modelo.idModelo);
                    cmd.Parameters.AddWithValue("@idEmpresa", novoVeiculo.Empresa.idEmpresa);
                    cmd.Parameters.AddWithValue("@placa", novoVeiculo.placa);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryDelete = "DELETE FROM VEICULO WHERE idVeiculo = @idVeiculo";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomains> ListarTodos()
        {
            List<VeiculoDomains> listaVeiculo = new List<VeiculoDomains>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idVeiculo, idModelo, idEmpresa, placa FROM VEICULO";

                con.Open();

                //Declarando  SqlDataReader rdr percorrer a tabela do nosso banco de dados.
                SqlDataReader rdr;

                //Declara o SqlCommand passando da query que será executada e a conexão com parametros.
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //executa a query e armeza os dados no rdr. 
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver registros para serem lidos no rdr, o laço se repete.
                    while (rdr.Read())
                    {
                        //instancia um objeto genero do tipo GeneroDomain
                        VeiculoDomains veiculo = new VeiculoDomains()
                        {
                            //atribui a propriedade idGenero o valor da primeira coluna do bando de dados.
                            idVeiculo = Convert.ToInt32(rdr[0]),

                            //atribui a propriedade  o valor da segunda coluna da tabela do banco de dados.
                            Modelo = new ModeloDomains()
                            {
                                idModelo = Convert.ToInt32(rdr[1]),
                            },                           

                            Empresa = new EmpresaDomains()
                            {
                                idEmpresa = Convert.ToInt32(rdr[2])
                            },                          

                            placa = rdr[3].ToString()
                        };
                        
                        listaVeiculo.Add(veiculo);
                    }
                }
            }
            return listaVeiculo;
        }
    }
}