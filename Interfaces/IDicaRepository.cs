using Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Interfaces
{
    interface IDicaRepository
    {
        /// <summary>
        /// Lista todos as dicas na plataforma
        /// </summary>
        /// <returns>retorna uma lista de dicas</returns>
        List<Dica> Listar();

        Dica BuscarPorId(Guid id);

        /// <summary>
        /// Adiciona novas dicas
        /// </summary>
        /// <param name="dica">Dica</param>
        void Adicionar(Dica dica);

        /// <summary>
        /// filtro por texto
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        List<Dica> BuscarPorNome(string texto);

        /// <summary>
        /// altera a dica existente
        /// </summary>
        /// <param name="dica">Dica</param>
        void Editar(Dica dica);

        /// <summary>
        /// Deleta o dica pelo id
        /// </summary>
        /// <param name="id">id da dica</param>
        void Remover(Guid id);

        //DataUltimoAcesso???


    }
}