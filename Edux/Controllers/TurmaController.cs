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
        /// <returns>Lista com todos as turmas</returns>
        /// GET api/Turma/5
        [HttpGet]
        public IActionResult Get()
        { 
            try
            {
                var turmas = _turmaRepository.Listar();

                //Verifico se existe a turma cadastrada

                if (turmas.Count == 0)
                    return NoContent();

                //Caso exista retorno Ok e as turmas cadastrados
                return Ok(new
                {
                    totalCount = turmas.Count,
                    data = turmas

                });

            }
            catch (Exception)

            {

                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Ocorreu um erro no endpoint Get/produtos.",
                });
            }
        }

        /// <summary>
        /// Mostra um único produto
        /// </summary>
        /// <param name="id">ID do produto</param>
        /// <returns>Um produto</returns>
        // GET api/produtos/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           try
           {

                //Busco o produto pelo Id
                Turma turma = _turmaRepository.BuscarPorId(id);

                //Caso não exista retorna NotFound

                if (turma == null)
                    return NotFound();

                //Caso exista retorno Ok e os dados do produto
                return Ok(turma);

            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);

            }

        }

        /// <summary>
        /// Cadastra um novo turma
        /// </summary>
        /// <param name="turma">Objeto turma</param>
        /// <returns>Turma cadastrado</returns>
        // POST api/Turma
        [HttpPost]
        public IActionResult Post([FromBody] Turma turma)
        {
            try
            {
                //Adiciona uma nova turma
                _turmaRepository.Adicionar(turma);


                //Retorna Ok caso a turma tenha sido cadastrado
                return Ok(turma);

            }
            catch (Exception ex)
            {
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
                //Edita o produto

                _turmaRepository.Editar(turma, id);

                //Retorna Ok com os dados do produto

                return Ok(turma);
            }
            catch (Exception ex)

            {

                return BadRequest(ex.Message);

            }

        }


        /// <summary>
        /// Método que exclui um turma
        /// </summary>
        /// <param name="id">Id da turma</param>
        /// <returns>Id excluído</returns>
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
                return BadRequest(ex.Message);
            }
        }
    }
}
