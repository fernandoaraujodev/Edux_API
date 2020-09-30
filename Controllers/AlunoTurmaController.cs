using System;
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
    public class AlunoTurmaController : ControllerBase
    {

        private readonly IAlunoTurmaRepository _alunoTurmaRepository;
        public AlunoTurmaController()
        {
            _alunoTurmaRepository = new AlunoTurmaRepository();
        }

        // POST 

        /// <summary>
        /// Cadastra AlunoTurma
        /// </summary>
        /// <param name="alunoTurma">alunoturma</param>
        /// <returns>alunoturma cadastrado</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post([FromBody] AlunoTurma alunoTurma)
        {
            try
            {
                if (alunoTurma.Matricula != null)

                    //Adiciona um aluno turma
                    _alunoTurmaRepository.Adicionar(alunoTurma);

                //retorna ok com os dados do aluno turma
                return Ok(alunoTurma);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        //GET BY ID

        /// <summary>
        /// Busca AlunoTurma por id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>alunoturma</returns>
        [Authorize(Roles = "Administrador, Professor, Aluno")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                //Busca o alunoturma no repositorio
                AlunoTurma alunoTurma = _alunoTurmaRepository.BuscarPorId(id);

                //Verfifica se o alunoturma existe
                //Caso alunoturma não exista retorna NotFound
                if (alunoTurma == null)
                    return NotFound();

                //Caso alunoturma exista retorna
                //Ok e os dados do alunoturma
                return Ok(alunoTurma);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem de erro
                return BadRequest(ex.Message);
            }
        }


        // GET

        /// <summary>
        /// Cadastra Lista de AlunoTurma 
        /// </summary>
        /// <returns>Mosta Lista de alunoturma cadastrados</returns>
        [Authorize(Roles = "Administrador, Professor, Aluno")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lista os alunoturma no repositorio
                var alunoTurma = _alunoTurmaRepository.Listar();

                //Verifica se existe alunoturma, caso não exista retorna
                //NoContent - Sem conteúdo
                if (alunoTurma.Count == 0)
                    return NoContent();

                //Caso exista retorna Ok e os alunoturma cadastrados
                return Ok(new
                {
                    totalCount = alunoTurma.Count,
                    data = alunoTurma

                });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    StatusCode = 400,
                    error = "Ocorreu um erro no endpoint Get/perfil, enviei um e-mail para email@email.com informando"
                });
            }
        }


        // PUT 

        /// <summary>
        /// Altera AlunoTurma Cadastrado
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="alunoTurma">alunoturma</param>
        /// <returns>alunoturma alterado</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoTurma alunoTurma)
        {
            try
            {
                var alunoTurmaTemp = _alunoTurmaRepository.BuscarPorId(id);
                if (alunoTurmaTemp == null)
                    return NotFound();

                _alunoTurmaRepository.Editar(id, alunoTurma);

                return Ok(alunoTurma);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        // DELETE 

        /// <summary>
        /// Deleta Id cadastrado de AlunoTurma
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>id removido</returns>
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _alunoTurmaRepository.Remover(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem de erro
                return BadRequest(ex.Message);
            }
        }
    }
}
