using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edux.Domains;
using Edux.Interfaces;
using Edux.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Edux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurtidaController : ControllerBase
    {
        private readonly ICurtidaRepository _curtidaRepository;

        public CurtidaController()
        {
            _curtidaRepository = new CurtidaRepository();
        }

        /// <summary>
        /// Esse endpoint é o que ira listar todas as curtidas cadastradas no banco de dados
        /// </summary>
        /// <returns>Se ainda não tiver curtidas cadastradas retorna 204 - Sem conteúdo ou retorna uma lista com todas as curtidas</returns>
        // GET: api/<CurtidaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Recebe a lista de curtidas
                var curtidas = _curtidaRepository.Listar();

                // Se a variável estiver nula a api retorna NoContent - Sem conteúdo
                if (curtidas == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(new
                    {
                        // Retorna 200 - Ok  e as curtidas cadastradas
                        // Conta todas as curtidas
                        totalCount = curtidas.Count(),
                        data = curtidas
                    });
                }

            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Erro no endpoint Get - Entrar em contato com o departamento técnico"
                });
            }
        }

        /// <summary>
        /// Método que busca a curtida com o id informado
        /// </summary>
        /// <param name="id">Id da curtida</param>
        /// <returns>Objeto Curtida</returns>
        // GET api/<CurtidaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                // Objeto do tipo curtida que recebe um objeto do método BuscarPorId 
                Curtida curtidas = _curtidaRepository.BuscarPorId(id);

                // Se o objeto curtida estiver nulo o endpoint retorna NotFound - Não encontrado para o frontend 
                if (curtidas == null)
                {
                    return NotFound();
                }
                else
                {
                    // Se o objeto for encontrado retorna 200 - Ok, junto com o objeto encontrado
                    return Ok(curtidas);
                }
            }
            catch (Exception ex)
            {
                // Se ocorrer alguma exceção retorna a messagem de erro para o frontend
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para cadastrar uma nova curtida
        /// </summary>
        /// <param name="curtida">Objeto Curtida</param>
        // POST api/<CurtidaController>
        [HttpPost]
        public IActionResult Post([FromBody] Curtida curtida)
        {
            try
            {
                //Adiciona uma nova curtida
                _curtidaRepository.Adicionar(curtida);

                //Retorna statusCode 200 - Ok, junto com a Curtida cadastrada
                return Ok(curtida);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para deletar uma curtida
        /// </summary>
        /// <param name="id">Id da curtida</param>
        /// <returns>Objeto Curtida</returns>
        // DELETE api/<CurtidaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Curtida curtidas = _curtidaRepository.BuscarPorId(id);

                if (curtidas == null)
                {
                    return NotFound();
                }
                else
                {
                    //Passa o id da curtida que será excluída
                    _curtidaRepository.Remover(id);

                    return Ok(curtidas);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}