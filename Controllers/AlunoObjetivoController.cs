using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edux.Domains;
using Edux.Interfaces;
using Edux.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Edux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoObjetivoController : ControllerBase
    {
        private readonly IAlunoObjetivoRepository _alunoObjetivoRepository;

        public AlunoObjetivoController()
        {
            _alunoObjetivoRepository = new AlunoObjetivoRepository();
        }

        /// <summary>
        /// Esse endpoint é o que ira listar todas os alunos e objetivos da tabela AlunoObjetivo cadastrados no banco de dados
        /// </summary>
        /// <returns>Se ainda não tiver instituição cadastradas retorna 204 - Sem conteúdo ou retorna uma lista com todas as instituições</returns>
        // GET: api/<AlunoObjetivoController>
        [Authorize(Roles = "Administrador, Professor, Aluno")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Recebe a lista de AlunosObjetivos
                var alunoObjetivoTemp = _alunoObjetivoRepository.Listar();

                // Se a variável estiver nula a api retorna NoContent - Sem conteúdo
                if (alunoObjetivoTemp == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(new
                    {
                        // Retorna 200 - Ok  e  os AlunosObjetivos cadatrados
                        // Conta os AlunosObjetivos
                        totalCount = alunoObjetivoTemp.Count(),
                        data = alunoObjetivoTemp
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
        /// Método que busca um AlunoObjetivo com o id informado
        /// </summary>
        /// <param name="id">Id do AlunoObjetivo</param>
        /// <returns>Objeto  AlunoObjetivo</returns>
        // GET api/<AlunoObjetivoController>/5
        [Authorize(Roles = "Administrador, Professor, Aluno")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                // Objeto do tipo AlunoObjetivo que recebe um objeto do método BuscarPorId 
                AlunoObjetivo alunoObjetivoTemp = _alunoObjetivoRepository.BuscarPorId(id);

                // Se o objeto inst estiver nulo o endpoint retorna NotFound - Não encontrado para o frontend 
                if (alunoObjetivoTemp == null)
                {
                    return NotFound();
                }
                else
                {
                    // Se o objeto for encontrado retorna 200 - Ok, junto com o objeto encontrado
                    return Ok(alunoObjetivoTemp);
                }
            }
            catch (Exception ex)
            {
                // Se ocorrer alguma exceção retorna a messagem de erro para o frontend
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para cadastrar um novo AlunoObjetivo
        /// </summary>
        /// <param name="alunoObjetivo">Objeto do tipo AlunoObjetivo</param>
        // POST api/<AlunoObjetivoController>
        [Authorize(Roles = "Professor")]
        [HttpPost]
        public IActionResult Post([FromBody] AlunoObjetivo alunoObjetivo)
        {
            try
            {
                //Adiciona um novo AlunoObjetivo
                _alunoObjetivoRepository.Adicionar(alunoObjetivo);

                //Retorna statusCode 200 - Ok, junto com o AlunoObjetivo cadastrado
                return Ok(alunoObjetivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para alterar um AlunoObjetivo
        /// </summary>
        /// <param name="id">Id do AlunoObjetivo que será alterada</param>
        /// <param name="alunoObjetivo">Objeto AlunoObjetivo</param>
        // PUT api/<AlunoObjetivoController>/5
        [Authorize(Roles = "Professor")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AlunoObjetivo alunoObjetivo)
        {
            try
            {
                _alunoObjetivoRepository.Editar(alunoObjetivo, id);

                return Ok(alunoObjetivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Método para deletar um AlunoObjetivo
        /// </summary>
        /// <param name="id">Id do AlunoObjetivo</param>
        /// <returns>Objeto AlunoObjetivo</returns>
        // DELETE api/<AlunoObjetivoController>/5
        [Authorize(Roles = "Professor")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                AlunoObjetivo alunoObjetivo = _alunoObjetivoRepository.BuscarPorId(id);

                if (alunoObjetivo == null)
                {
                    return NotFound();
                }
                else
                {
                    //Passa o id do AlunoObjetivo que será excluído
                    _alunoObjetivoRepository.Remover(id);

                    return Ok(alunoObjetivo);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}