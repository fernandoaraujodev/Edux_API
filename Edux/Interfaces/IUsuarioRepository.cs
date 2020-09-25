using Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuarios na plataforma
        /// </summary>
        /// <returns>retorna uma lista de usuarios</returns>
        List<Usuario> Listar();

        Usuario BuscarPorId(Guid id);

        /// <summary>
        /// Adiciona novos usuario
        /// </summary>
        /// <param name="usuario">Usuario</param>
        void Adicionar(Usuario usuario);

        /// <summary>
        /// filtro por nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        List<Usuario> BuscarPorNome(string nome);

        /// <summary>
        /// altera o usuario existente
        /// </summary>
        /// <param name="usuario">Usuario</param>
        void Editar(Usuario usuario);

        /// <summary>
        /// Deleta o usuario pelo id
        /// </summary>
        /// <param name="id">id do usuario</param>
        void Remover(Guid id);

        //DataUltimoAcesso???


    }
}
