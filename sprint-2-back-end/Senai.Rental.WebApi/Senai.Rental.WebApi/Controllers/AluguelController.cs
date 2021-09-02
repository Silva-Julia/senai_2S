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
    public class AluguelController : ControllerBase
    {
       
        private IAluguelRepository _aluguelRepository { get; set; }
      
        public AluguelController()
        {
            _aluguelRepository = new AluguelRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            //Criar uma lista nomeada listaGeneros para receber os dados.
            List<AluguelDomains> listaAlugueis = _aluguelRepository.ListarTodos();

            //Retorna o status code 200(OK) com a lista de gêneros no formato JSON
            return Ok(listaAlugueis);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AluguelDomains aluguelBuscado = _aluguelRepository.BuscarPorId(id);

            if (aluguelBuscado == null)
            {
                return NotFound("Nenhum aluguel encontrado!");
            }

            return Ok(aluguelBuscado);
        }


        [HttpPost]
        public IActionResult Post(AluguelDomains novoAluguel)
        {
            //Faz a chamada para o método .cadastrar
            _aluguelRepository.Cadastrar(novoAluguel);

            //Retorna um status code 201 - Created
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, AluguelDomains aluguelAtualizado)
        {
            AluguelDomains aluguelBuscado = _aluguelRepository.BuscarPorId(id);

            if (aluguelBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Aluguel não encontrado!",
                            erro = true
                        }
                    );
            }

            try
            {
                _aluguelRepository.AtualizarIdUrl(id, aluguelAtualizado);

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
            _aluguelRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return NoContent();
        }
    }
}
