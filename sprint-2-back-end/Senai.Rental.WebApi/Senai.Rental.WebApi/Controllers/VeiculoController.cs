using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interface;
using Senai.Rental.WebApi.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private IVeiculosRepository _veiculoRepository { get; set; }

        public VeiculoController()
        {
            _veiculoRepository = new VeiculoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            
            List<VeiculoDomains> listaVeiculos = _veiculoRepository.ListarTodos();

            return Ok(listaVeiculos);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            VeiculoDomains VeiculoBuscado = _veiculoRepository.BuscarPorId(id);

            if (VeiculoBuscado == null)
            {
                return NotFound("Nenhum Veiculo encontrado!");
            }

            return Ok(VeiculoBuscado);
        }


        [HttpPost]
        public IActionResult Post(VeiculoDomains novoVeiculo)
        {
            
            _veiculoRepository.Cadastrar(novoVeiculo);

         
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, VeiculoDomains VeiculoAtualizado)
        {
            VeiculoDomains VeiculoBuscado = _veiculoRepository.BuscarPorId(id);

            if (VeiculoBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Veiculo não encontrado!",
                            erro = true
                        }
                    );
            }

            try
            {
                _veiculoRepository.AtualizarIdUrl(id, VeiculoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="id">id do gênero que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// ex: http://localhost:5000/api/generos/excluir/9
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar()
            _veiculoRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return NoContent();
        }
    }
}
