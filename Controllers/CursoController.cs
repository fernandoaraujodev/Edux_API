using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Edux.Contexts;
using Edux.Domains;
using Microsoft.AspNetCore.Authorization;
using Edux.Interfaces;
using Edux.Repositories;

namespace Edux.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoController()
        {
            _cursoRepository = new CursoRepository();
        }


        // GET: api/Curso
        /// <summary>
        /// Mostra todos os cursos criados
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrador, Aluno, Professor")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var cursos = _cursoRepository.Listar();

                // Se a variável estiver nula a api retorna NoContent - Sem conteúdo
                if (cursos == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(new
                    {
                        totalCount = cursos.Count(),
                        data = cursos
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

        // GET: api/Curso/5
        /// <summary>
        /// Busca o curso de acordo com o id passado
        /// </summary>
        /// <param name="id">id curso</param>
        /// <returns>retorna o curso pertencente ao id</returns>
        [Authorize(Roles = "Administrador, Aluno, Professor")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Curso curso = _cursoRepository.BuscarPorId(id);

                if (curso == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(curso);
                }
            }
            catch (Exception ex)
            {
                // Se ocorrer alguma exceção retorna a messagem de erro para o frontend
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Curso
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Cadastra um novo curso
        /// </summary>
        /// <param name="curso">objeto curso</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post([FromBody] Curso curso)
        {
            try
            {
                _cursoRepository.Adicionar(curso);

                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Curso/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Altera um curso com o id informado
        /// </summary>
        /// <param name="id">id do curso</param>
        /// <param name="curso">objeto curso</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Curso curso)
        {
            try
            {
                _cursoRepository.Editar(curso, id);

                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE: api/Curso/5
        /// <summary>
        /// Remove um curso com o id informado
        /// </summary>
        /// <param name="id">id do curso</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Curso curso = _cursoRepository.BuscarPorId(id);

                if (curso == null)
                {
                    return NotFound();
                }
                else
                {
                    _cursoRepository.Remover(id);

                    return Ok(curso);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}