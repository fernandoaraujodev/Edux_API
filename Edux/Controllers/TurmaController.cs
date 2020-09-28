using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edux.Domains;
using Edux.Interfaces;
using Edux.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaController()
        {
            _turmaRepository = new TurmaRepository();

        }


        /// <summary>
        /// Método que mostra todas as turmas cadastradas 
        /// </summary>
        /// <returns>Lista com todas as turmas</returns>
        /// GET api/Turma
        [HttpGet]
        public IActionResult Get()
        { 
            try
            {
                var turmas = _turmaRepository.Listar();

                //Verifica se existe a turma cadastrada

                if (turmas.Count == 0)
                    return NoContent();

                //Caso exista retorno Ok e as turmas cadastradas
                return Ok(new
                {
                    totalCount = turmas.Count,
                    data = turmas

                });

            }
            catch (Exception)

            {
                //Retorna uma mensagem de erro, caso tenha ocorrido alguma exceção

                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Ocorreu um erro no endpoint Get/produtos.",
                });
            }
        }

        /// <summary>
        /// Mostra uma única turma
        /// </summary>
        /// <param name="id">ID da turma</param>
        /// <returns>Objeto turma</returns>
        // GET api/Turma/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           try
           {

                //Busca a Turma pelo Id
                Turma turma = _turmaRepository.BuscarPorId(id);

                //Caso não exista retorna NotFound

                if (turma == null)
                    return NotFound();

                //Caso exista retorno Ok e os dados da turma
                return Ok(turma);

            }
            catch (Exception ex)
            {
                //Retorna uma mensagem de erro, caso tenha ocorrido alguma exceção
                return BadRequest(ex.Message);

            }

        }

        /// <summary>
        /// Cadastra um nova turma
        /// </summary>
        /// <param name="turma">Objeto turma</param>
        /// <returns>Turma cadastrada</returns>
        // POST api/Turma
        [HttpPost]
        public IActionResult Post([FromBody] Turma turma)
        {
            try
            {
                //Adiciona uma nova turma
                _turmaRepository.Adicionar(turma);

                //Retorna Ok caso a turma tenha sido cadastrada
                return Ok(turma);

            }
            catch (Exception ex)
            {
                //Retorna uma mensagem de erro, caso tenha ocorrido alguma exceção
                return BadRequest(ex.Message);
            }

        }


        /// <summary>
        /// Método que altera determinada turma
        /// </summary>
        /// <param name="id">ID da Turma</param>
        /// <param name="turma">Objeto Turma</param>
        /// <returns>Objeto Turma com as informações alteradas</returns>
        // PUT api/Turma/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Turma turma)
        {
            try
            {
                //Edita a turma

                _turmaRepository.Editar(turma, id);

                //Retorna Ok com os dados da turma

                return Ok(turma);
            }
            catch (Exception ex)

            {
                //Retorna uma mensagem de erro, caso tenha ocorrido alguma exceção
                return BadRequest(ex.Message);

            }

        }


        /// <summary>
        /// Método que exclui um turma
        /// </summary>
        /// <param name="id">Id da turma</param>
        /// <returns>O id excluído</returns>
        // DELETE api/produtos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var turma = _turmaRepository.BuscarPorId(id);

                if (turma == null)

                    return NotFound();

                _turmaRepository.Remover(id);

                //Retorna Ok - statusCode 200

                return Ok(id);
            }
            catch (Exception ex)
            {
                //Retorna uma mensagem de erro, caso tenha ocorrido alguma exceção
                return BadRequest(ex.Message);
            }
        }
    }
}
