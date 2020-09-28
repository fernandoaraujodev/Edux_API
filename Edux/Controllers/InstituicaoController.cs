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
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        /// <summary>
        /// Esse endpoint é o que ira listar todas as instituições cadastradas no banco de dados
        /// </summary>
        /// <returns>Se ainda não tiver instituição cadastradas retorna 204 - Sem conteúdo ou retorna uma lista com todas as instituições</returns>
        // GET: api/<InstituicaoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Recebe a lista de instituições
                var instituicoes = _instituicaoRepository.Listar();

                // Se a variável estiver nula a api retorna NoContent - Sem conteúdo
                if(instituicoes == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(new
                    {
                        // Retorna 200 - Ok  e as instituições cadastradas
                        // Conta todas as instituições
                        totalCount = instituicoes.Count(),
                        data = instituicoes
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
        /// Método que busca a instituição com o id informado
        /// </summary>
        /// <param name="id">Id da instituição</param>
        /// <returns>Objeto instituição</returns>
        // GET api/<InstituicaoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                // Objeto do tipo instituição que recebe um objeto do método BuscarPorId 
                Instituicao inst = _instituicaoRepository.BuscarPorId(id);

                // Se o objeto inst estiver nulo o endpoint retorna NotFound - Não encontrado para o frontend 
                if(inst == null)
                {
                    return NotFound();
                }
                else
                {
                    // Se o objeto for encontrado retorna 200 - Ok, junto com o objeto encontrado
                    return Ok(inst);
                }
            }
            catch (Exception ex)
            {
                // Se ocorrer alguma exceção retorna a messagem de erro para o frontend
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Método para cadastrar uma nova instituição
        /// </summary>
        /// <param name="inst">Objeto instituição</param>
        // POST api/<InstituicaoController>
        [HttpPost]
        public IActionResult Post([FromForm] Instituicao inst)
        {
            try
            {
                //Adiciona uma nova instituição
                _instituicaoRepository.Adicionar(inst);

                //Retorna statusCode 200 - Ok, junto com a instituição cadastrada
                return Ok(inst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para alterar uma instituição
        /// </summary>
        /// <param name="id">Id da instituição que será alterada</param>
        /// <param name="inst">Dados da instituição que será aletrada</param>
        // PUT api/<InstituicaoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] Instituicao inst)
        {
            try
            {
                Instituicao instituicaoTemp = _instituicaoRepository.BuscarPorId(id);

                if(instituicaoTemp == null)
                {
                    return NotFound();
                }
                else
                {
                    _instituicaoRepository.Editar(inst);

                    return Ok(inst);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Método para deletar uma instituição
        /// </summary>
        /// <param name="id">Id da instituição</param>
        /// <returns></returns>
        // DELETE api/<InstituicaoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Instituicao inst = _instituicaoRepository.BuscarPorId(id);

                if(inst == null)
                {
                    return NotFound();
                }
                else
                {
                    //Passa o id da instituição que será excluída
                    _instituicaoRepository.Remover(id);

                    return Ok(inst);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
