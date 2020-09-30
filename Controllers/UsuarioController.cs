using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Edux.Contexts;
using Edux.Domains;
using Edux.Interfaces;
using Edux.Repositories;
using Edux.Utils;

namespace Edux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Mostra todos os usuários cadastrados
        /// </summary>
        /// <returns>retorna uma lista com todas os usuários</returns>
        // GET: api/<UsuarioController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var usuario = _usuarioRepository.Listar();

                if (usuario.Count == 0)
                    return NoContent();

                return Ok(usuario);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Busca o usuário com o id passado
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <returns>Objeto usuário</returns>
        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                // Objeto do tipo usuário que recebe um objeto do método BuscarPorId 
                Usuario user = _usuarioRepository.BuscarPorId(id);

                // Se o objeto estiver nulo retorna NotFound 
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    // Se o objeto for encontrado retorna 200
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                // Se ocorrer alguma exceção retorna a mensagem de erro para o frontend
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">Objeto Usuario</param>
        // POST api/<UsuarioController>
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                // Criptografamos antes de salvar a senha
                usuario.Senha = Cripto.Criptografar(usuario.Senha, usuario.Email.Substring(0, 3));

                //Adiciona um novo usuário
                _usuarioRepository.Adicionar(usuario);

                //statusCode 200
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Altera um usuário
        /// </summary>
        /// <param name="id">Id do usuario que será alterada</param>
        /// <param name="usuario">Dados do usuário que serão alterados</param>
        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario usuario)
        {
            try
            {
                _usuarioRepository.Editar(id, usuario);

                // Criptografamos antes de salvar a senha
                usuario.Senha = Cripto.Criptografar(usuario.Senha, usuario.Email.Substring(0, 3));

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Remove um usuário
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <returns></returns>
        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Usuario usuario = _usuarioRepository.BuscarPorId(id);

                if (usuario == null)
                {
                    return NotFound();
                }
                else
                {
                    //Passa o id do usuario que será excluído
                    _usuarioRepository.Remover(id);

                    return Ok(usuario);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}