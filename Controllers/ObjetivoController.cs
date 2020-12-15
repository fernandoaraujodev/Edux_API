using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edux.Domains;
using Edux.Interfaces;
using Edux.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetivoController : ControllerBase
    {
        private readonly IObjetivoRepository _objRepository;

        public ObjetivoController()
        {
            _objRepository = new ObjetivoRepository();
        }

        /// <summary>
        /// Mostra todos os objetivos cadastrados
        /// </summary>
        /// <returns>retorna uma lista com todas os objetivos</returns>
        // GET: api/<ObjetivoController>
        [Authorize(Roles = "Administrador, Professor, Aluno")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var obj = _objRepository.Listar();

                if (obj.Count == 0)
                    return NoContent();

                return Ok(obj);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Busca o objetivo com o id informado
        /// </summary>
        /// <param name="id">Id do objetivo</param>
        /// <returns>Objeto objetivo</returns>
        // GET api/<ObjetivoController>/5
        [Authorize(Roles = "Administrador, Professor, Aluno")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Objetivo obj = _objRepository.BuscarPorId(id);

                if (obj == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(obj);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Cadastra um novo objetivo
        /// </summary>
        /// <param name="obj">Objeto objetivo</param>
        // POST api/<ObjetivoController>
        [Authorize(Roles = "Professor")]
        [HttpPost]
        public IActionResult Post([FromBody] Objetivo obj)
        {
            try
            {
                _objRepository.Adicionar(obj);

                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Altera um objetivo
        /// </summary>
        /// <param name="id">Id do objetivo que será alterado</param>
        /// <param name="obj">informações do objetivo que serão alterado</param>
        // PUT api/<ObjetivoController>/5
        [Authorize(Roles = "Professor")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Objetivo obj)
        {
            try
            {
                _objRepository.Editar(id, obj);

                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Remove um objetivo
        /// </summary>
        /// <param name="id">Id do objetivo</param>
        /// <returns></returns>
        // DELETE api/<ObjetivoController>/5
        [Authorize(Roles = "Professor")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var obj = _objRepository.BuscarPorId(id);

                if (obj == null)
                    return NotFound();

                _objRepository.Remover(id);
                return Ok(obj);
       
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
