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
using Edux.Utils;

namespace Edux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DicaController : ControllerBase
    {
        private readonly IDicaRepository _dicaRepository;

        public DicaController()
        {
            _dicaRepository = new DicaRepository();
        }

        /// <summary>
        /// Mostra as dicas cadastradas no dbSet 
        /// </summary>
        /// <returns>Lista com todas as dicas</returns>
        [Authorize(Roles = "Professor, Administrador, Aluno")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var dica = _dicaRepository.Listar();

                if (dica.Count == 0)
                    return NoContent();

                //Caso exista retorno Ok e as dicas cadastradas
                return Ok(new
                {
                    totalCount = dica.Count,
                    data = dica
                });
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Ocorreu um erro no endpoint Get/dica, envie um e-mail para email@email.com informando"
                });
            }
        }

        /// <summary>
        /// Mostra uma única dica
        /// </summary>
        /// <param name="id">ID da Dica</param>
        /// <returns>Uma Dica</returns>
        [Authorize(Roles = "Professor, Administrador, Aluno")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Dica dica = _dicaRepository.BuscarPorId(id);

                if (dica == null)
                    return NotFound();

                return Ok(dica);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastra uma nova dica
        /// </summary>
        /// <param name="dica">Objeto completo Dica</param>
        /// <returns>Dica cadastrada</returns>
        [Authorize(Roles = "Professor")]
        [HttpPost]
        public IActionResult Post([FromForm] Dica dica)
        {
            try
            {
                if (dica.Img != null)
                {
                    var Imagem = Upload.Local(dica.Img);

                    dica.Imagem = Imagem;
                }

                //Adiciona uma nova dica
                _dicaRepository.Adicionar(dica);

                return Ok(dica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Altera determinada Dica
        /// </summary>
        /// <param name="id">ID da Dica</param>
        /// <param name="dica">Objeto Dica com as alterações</param>
        /// <returns>Info da Dica alterada</returns>
        [Authorize(Roles = "Professor")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Dica dica)
        {
            try
            {
                _dicaRepository.Editar(dica, id);

                //Retorna Ok com os dados do produto
                return Ok(dica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui uma dica
        /// </summary>
        /// <param name="id">ID da dica</param>
        /// <returns>ID excluído</returns>
        [Authorize(Roles = "Professor")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var dica = _dicaRepository.BuscarPorId(id);

                if (dica == null)
                    return NotFound();

                _dicaRepository.Remover(id);
                //Retorna Ok
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}