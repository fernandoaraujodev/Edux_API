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
    public class DicaRepository : IDicaRepository
    {
        private readonly EduxContext _ctx;

        public DicaRepository()
        {
            _ctx = new EduxContext();
        }

        #region Leitura
        /// <summary>
        /// Lista todas as dicas cadastrados
        /// </summary>
        /// <returns>Retorna uma Lista de Dicas</returns>
        public List<Dica> Listar()
        {
            try
            {
                return _ctx.Dica.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca uma dica pelo seu Id
        /// </summary>
        /// <param name="id">Id da Dica</param>
        /// <returns>Objeto Dica</returns>
        public Dica BuscarPorId(int id)
        {
            try
            {
                
                return _ctx.Dica
                    .Include(c => c.IdUsuarioNavigation)
                    .FirstOrDefault(x => x.IdDica == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Gravação
        /// <summary>
        /// Edita uma Dica
        /// </summary>
        /// <param name="dica">Dica a ser editada</param>
        /// <param name="id">Id da dica</param>
        public void Editar(Dica dica, int id)
        {
            try
            {
                Dica dicaTemp = BuscarPorId(id);

                if (dicaTemp == null)
                    throw new Exception("Dica não encontrada");

                //Caso exista altera sua propriedades
                dicaTemp.Texto = dica.Texto;
                dicaTemp.IdUsuario = dica.IdUsuario;

                _ctx.Dica.Update(dicaTemp);
                //Salva o contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona uma nova Dica
        /// </summary>
        /// <param name="dica">Objeto do tipo Dica</param>
        public void Adicionar(Dica dica)
        {
            try
            {
                _ctx.Dica.Add(dica);
                
                //Salva as alterações no contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove uma Dica
        /// </summary>
        /// <param name="id">Id da Dica</param>
        public void Remover(int id)
        {
            try
            {
                Dica dicaTemp = BuscarPorId(id);

                //Remove a dica do dbSet
                _ctx.Dica.Remove(dicaTemp);
                //Salva as alteráções do contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}