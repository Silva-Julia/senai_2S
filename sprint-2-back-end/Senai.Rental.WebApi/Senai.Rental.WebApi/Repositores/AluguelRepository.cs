using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.Rental.WebApi.Repositores
{
    public class AluguelRepository : IAluguelRepository
    {
        private string stringConexao = "Data Source=NOTE0113G5\\SQLEXPRESS; initial catalog=T_Rental_Julia; user Id=sa; pwd=Senai@132";

        public void AtualizarIdUrl(int idAluguel, AluguelDomains AluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE ALUGUEL SET = @idCliente,  @idVeiculo, @dataInicio, @dataFim WHERE idAluguel = @idAluguel";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);
                    cmd.Parameters.AddWithValue("@idVeiculo", AluguelAtualizado.Veiculo.idVeiculo);
                    cmd.Parameters.AddWithValue("@idCliente", AluguelAtualizado.Cliente.idCliente);
                    cmd.Parameters.AddWithValue("@dataInicio", AluguelAtualizado.dataInicio);
                    cmd.Parameters.AddWithValue("@dataFim", AluguelAtualizado.dataFim);
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomains BuscarPorId(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idAluguel, idVeiculo, idCliente, dataInicio, dataFim FROM ALUGUEL WHERE idAluguel = @idAluguel";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        AluguelDomains AluguelBuscado = new AluguelDomains()
                        {
                            idAluguel = Convert.ToInt32(reader["idAluguel"]),

                            Veiculo = new VeiculoDomains()
                            {
                                idVeiculo = Convert.ToInt32(reader["Veiculo"]),
                            },

                            Cliente = new ClienteDomains()
                            {
                                idCliente = Convert.ToInt32(reader["Cliente"])
                            },

                            dataInicio = Convert.ToDateTime(reader["dataInicio"]),

                            dataFim = Convert.ToDateTime(reader[" dataFim"])

                        };
                        return AluguelBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(AluguelDomains novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO ALUGUEL (idAluguel, idVeiculo, idCliente, dataInicio, dataFim) VALUES (@idAluguel)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", novoAluguel.idAluguel);
                    cmd.Parameters.AddWithValue("@idVeiculo", novoAluguel.Veiculo.idVeiculo);
                    cmd.Parameters.AddWithValue("@idCliente", novoAluguel.Cliente.idCliente);
                    cmd.Parameters.AddWithValue("@dataInicio", novoAluguel.dataInicio);
                    cmd.Parameters.AddWithValue("@dataFim", novoAluguel.dataFim);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryDelete = "DELETE FROM ALUGUEL WHERE idAluguel = @idAluguel";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomains> ListarTodos()
        {
            List<AluguelDomains> listaAluguel = new List<AluguelDomains>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idAluguel, idVeiculo, idCliente, dataInicio, dataFim FROM ALUGUEL";

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
                        AluguelDomains Aluguel = new AluguelDomains()
                        {
                            //atribui a propriedade idGenero o valor da primeira coluna do bando de dados.
                            idAluguel = Convert.ToInt32(rdr[0]),

                            //atribui a propriedade  o valor da segunda coluna da tabela do banco de dados.
                            Veiculo = new VeiculoDomains()
                            {
                                idVeiculo = Convert.ToInt32(rdr[1]),
                            },

                            Cliente = new ClienteDomains()
                            {
                                idCliente = Convert.ToInt32(rdr[2])
                            },

                            dataInicio = Convert.ToDateTime(rdr[3]),

                            dataFim = Convert.ToDateTime(rdr[4]),
                        };

                        listaAluguel.Add(Aluguel);
                    }
                }
            }
            return listaAluguel;
        }
    }
}
