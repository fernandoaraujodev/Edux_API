using System;
using Edux.Domains;
using Edux.Interfaces;
using Edux.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Edux.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfiIRepository _perfilRepository;
        public PerfilController()
        {
            _perfilRepository = new PerfilRepository();
        }

        //POST

        /// <summary>
        /// Cadastra um novo perfil
        /// </summary>
        /// <param name="perfil">Perfil</param>
        /// <returns>perfil cadastrado</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Perfil perfil)
        {
            try
            {
                if (perfil.Permissao != null)

                    //Adiciona um perfil
                    _perfilRepository.Adicionar(perfil);

                //retorna ok com os dados do perfil
                return Ok(perfil);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        //GET BY ID

        /// <summary>
        /// Mostra um único perfil especifico
        /// </summary>
        /// <param name="id">ID do perfil</param>
        /// <returns>Um perfil</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                //Busca o perfil no repositorio
                Perfil perfil = _perfilRepository.BuscarPorId(id);

                //Verfifica se o perfil existe
                //Caso perfil não exista retorna NotFound
                if (perfil == null)
                    return NotFound();

                //Caso perfil exista retorna
                //Ok e os dados do perfil
                return Ok(perfil);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        //GET

        /// <summary>
        /// Mostra todos os perfis cadastrados
        /// </summary>
        /// <returns>Lista com todos os perfis</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lista os perfis no repositorio
                var perfil = _perfilRepository.Listar();

                //Verifica se existe perfil, caso não exista retorna
                //NoContent - Sem conteúdo
                if (perfil.Count == 0)
                    return NoContent();

                //Caso exista retorna Ok e os perfis cadastrados
                return Ok(new
                {
                    totalCount = perfil.Count,
                    data = perfil

                });
            }
            catch(Exception ex)
            {
                //TODO : Cadastrar mensagem de erro no dominio logErro
                return BadRequest(new
                {
                    StatusCode = 400,
                    error = "Ocorreu um erro no endpoint Get/perfil, enviei um e-mail para email@email.com informando"
                });
            }
        }

        //PUT

        /// <summary>
        /// Altera determinado perfil
        /// </summary>
        /// <param name="id">ID do perfil</param>
        /// <param name="perfil">Objeto perfil co as alterações</param>
        /// <returns>Indo do perfil alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Perfil perfil)
        {
            try
            {
                var perfilTemp = _perfilRepository.BuscarPorId(id);
                if (perfilTemp == null)
                    return NotFound();

                _perfilRepository.Editar(id, perfil);

                return Ok(perfil);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        //DELETE

        /// <summary>
        /// Exclui um perfil
        /// </summary>
        /// <param name="id">ID do perfil</param>
        /// <returns>Id excluido</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _perfilRepository.Remover(id);
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
