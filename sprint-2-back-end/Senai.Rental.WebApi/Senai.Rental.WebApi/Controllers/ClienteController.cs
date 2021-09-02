using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interface;
using Senai.Rental.WebApi.Repositores;
using System;
using System.Collections.Generic;

namespace Senai.Rental.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private IClienteRepository _clienteRepository {get; set; }

        public ClienteController()
         {
           _clienteRepository = new ClienteRepository();
         }

         [HttpGet]
         public IActionResult Get()
         {
       
               List<ClienteDomains> listaClientes = _clienteRepository.ListarTodos();

              return Ok(listaClientes);

          }

         [HttpGet("{id}")]
          public IActionResult GetById(int id)
           {
                 ClienteDomains ClienteBuscado = _clienteRepository.BuscarPorId(id);

                 if (ClienteBuscado == null)
                  {
                        return NotFound("Nenhum cliente encontrado!");
                  }

                   return Ok(ClienteBuscado);
           }


           [HttpPost]
           public IActionResult Post(ClienteDomains novoCliente)
           {
                _clienteRepository.Cadastrar(novoCliente);

        
                 return StatusCode(201);
            }

            
           [HttpPut("{id}")]
           public IActionResult PutIdUrl(int id, ClienteDomains ClienteAtualizado)
            {
                ClienteDomains ClienteBuscado = _clienteRepository.BuscarPorId(id);

                if (ClienteBuscado == null)
                {
                    return NotFound(
                        new
                        { 
                        mensagem = "Cliente não encontrado!",
                        erro = true
                        }
                    );
                }

                 try
                  {
                       _clienteRepository.AtualizarIdUrl(id, ClienteAtualizado);

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
            /// ex: http://localhost:5000/api/Clientes/excluir/9
            [HttpDelete("excluir/{id}")]
             public IActionResult Delete(int id)
              {
        
                  _clienteRepository.Deletar(id);

                  return NoContent();
              }
      }
}
