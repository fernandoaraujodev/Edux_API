using Edux.Contexts;
using Edux.Domains;
using Edux.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Repositories
{
    public class CurtidaRepository : ICurtidaRepository
    {

        private readonly EduxContext _ctx;

        public CurtidaRepository()
        {
            _ctx = new EduxContext();
        }

        #region Leitura

        /// <summary>
        /// Método que busca uma curtida pelo id
        /// </summary>
        /// <param name="id">Id da curtida</param>
        /// <returns>Objeto Curtida</returns>
        public Curtida BuscarPorId(int id)
        {
            try
            {
                return _ctx.Curtida
                    .Include(c => c.IdUsuarioNavigation)
                    .Include(y => y.IdDicaNavigation)
                    .FirstOrDefault(x => x.IdCurtida == id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Lista todas as Curtidas
        /// </summary>
        /// <returns>Lista de curtidas cadastradas</returns>
        public List<Curtida> Listar()
        {
            try
            {
                return _ctx.Curtida
                                .Include(i => i.IdDicaNavigation)
                                .Include(y => y.IdUsuarioNavigation)
                                .ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Gravacao

        /// <summary>
        /// Método para adicionar uma nova curtida 
        /// </summary>
        /// <param name="curtida">Objeto do tipo curtida</param>
        public void Adicionar(Curtida curtida)
        {
            try
            {
                // O contexto recebe o objeto curtida do método
                _ctx.Add(curtida);

                //Salva as alterações no banco de dados Edux
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método que remove uma curtida do contexto
        /// </summary>
        /// <param name="id">Recebe o id da curtida</param>
        public void Remover(int id)
        {
            try
            {
                Curtida curtida = BuscarPorId(id);


                if (curtida == null)
                {
                    throw new Exception("Curtida não encontrada");
                }
                else
                {
                    //Remove a curtida informada do contexto
                    _ctx.Curtida.Remove(curtida);

                    //Salva todas as alterações
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
