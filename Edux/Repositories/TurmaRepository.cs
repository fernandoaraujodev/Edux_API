using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edux.Contexts;
using Edux.Domains;
using Edux.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Edux.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly EduxContext _ctx;

        public TurmaRepository()
        {
            _ctx = new EduxContext();

        }


        #region Leitura
        /// <summary>
        /// Método que lista todas as turmas
        /// </summary>
        /// <returns>Retorna uma Lista de Turmas</returns>
        public List<Turma> Listar()
        {
            try
            {

                return _ctx.Turma.ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        /// <summary>
        /// Método para buscar uma turma pelo seu Id
        /// </summary>
        /// <param name="id">Id da turma</param>
        /// <returns>Lista de turma</returns>
        public Turma BuscarPorId(int id)
        {
            try
            {

                return _ctx.Turma.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        /// <summary>
        /// Método que busca turmas pela descrição
        /// </summary>
        /// <param name="descricao">Descrição da turma</param>
        /// <returns>Retorna uma lista de turmas</returns>
        public List<Turma> BuscarPorNome(string descricao)
        {
            try
            {

                return _ctx.Turma
                           .Where(c => c.Descricao.Contains(descricao))
                           .ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        #endregion

        #region Gravação
        /// <summary>
        /// Método para editar uma turma
        /// </summary>
        /// <param name="turma">Objeto Turma</param>
        /// <param name="id">Id da turma</param>
        public void Editar(Turma turma, int id)
        {
            try
            {

                //Buscar turma pelo id
                Turma turmaTemp = BuscarPorId(id);

                //Verifica se a turma existe
                //Caso não existe gera uma exception

                if (turmaTemp == null)

                    throw new Exception("Turma não encontrada");

                //Caso exista altera sua propriedades

                turmaTemp.Descricao = turma.Descricao;
                turma.IdCurso = turma.IdCurso;

                _ctx.Turma.Update(turmaTemp);

                //Salva o contexto no banco de dados
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }



        /// <summary>
        /// Método que adiciona uma nova Turma
        /// </summary>
        /// <param name="turma">Objeto do tipo Turma</param>
        public void Adicionar(Turma turma)
        {
            try
            {

                _ctx.Turma.Add(turma);

               //Salva as alterações no contexto

                _ctx.SaveChanges();

            }

            catch (Exception ex)

            {

                throw new Exception(ex.Message);

            }
        }



        /// <summary>
        /// Método que remove uma turma
        /// </summary>
        /// <param name="id">Id da turma</param>
        public void Remover(int id)

        {

            try

            {

               
                Turma turmaTemp = BuscarPorId(id);

                //Remove a Turma do dbSet
                if (turmaTemp == null)
                    throw new Exception("Turma não existe");


                _ctx.Turma.Remove(turmaTemp);

                //Salva as alterações do contexto

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
