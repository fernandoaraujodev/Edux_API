using Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Interfaces
{
    interface ICursoRepository
    {
        /// <summary>
        /// Lista todos os cursos na plataforma
        /// </summary>
        /// <returns>retorna uma lista de cursos</returns>
        List<Curso> Listar();

        Curso BuscarPorId(Guid id);

        /// <summary>
        /// Adiciona novos curso
        /// </summary>
        /// <param name="curso">Curso</param>
        void Adicionar(Curso curso);

        /// <summary>
        /// filtro por titulo
        /// </summary>
        /// <param name="titulo"></param>
        /// <returns></returns>
        List<Curso> BuscarPorNome(string titulo);

        /// <summary>
        /// altera o curso existente
        /// </summary>
        /// <param name="curso">Curso</param>
        void Editar(Curso curso);

        /// <summary>
        /// Deleta o curso pelo id
        /// </summary>
        /// <param name="id">id do curso</param>
        void Remover(Guid id);

        //DataUltimoAcesso???


    }
}