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
    public class CursoRepository : ICursoRepository
    {
        private readonly EduxContext _ctx;

        public CursoRepository()
        {
            _ctx = new EduxContext();
        }

        #region Leitura

        
        /// <summary>
        /// Busca um curso pelo Id
        /// </summary>
        /// <param name="id">Id do curso</param>
        /// <returns>Objeto curso com o id informado</returns>
        public Curso BuscarPorId(int id)
        {
            try { 
            
                return _ctx.Curso.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Busca um curso pelo nome informado
        /// </summary>
        /// <param name="nome">String com o nome a ser buscado</param>
        /// <returns>Lista com de cursos com esse nome</returns>
        public List<Curso> BuscarPorNome(string nome)
        {
            try
            {
                // Busca um curso que contenha o nome informado
                return _ctx
                        .Curso
                        .Where(c => c.Titulo.Contains(nome))
                        .ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista todos os cursos na plataforma
        /// </summary>
        /// <returns>Lista de cursos</returns>
        public List<Curso> Listar()
        {
            try
            {
                return _ctx.Curso
                    .Include( x => x.IdInstituicaoNavigation)    
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
        /// Método para adicionar um novo curso 
        /// </summary>
        /// <param name="curso">Objeto do tipo curso</param>
        public void Adicionar(Curso curso)
        {
            try
            {
                _ctx.Add(curso);

                //Salva as alterações no banco de dados Edux
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Editar um curso
        /// </summary>
        /// <param name="curso">Objeto Curso</param>
        /// <param name="id">Id do Curso</param>
        public void Editar(Curso curso, int id)
        {
            try
            {
                Curso cursoTemp = BuscarPorId(id);

                if (cursoTemp == null)
                {
                    throw new Exception("Curso não encontrado");
                }
                else
                {
                    cursoTemp.Titulo = curso.Titulo;
                    cursoTemp.IdInstituicao = cursoTemp.IdInstituicao;

                    _ctx.Curso.Update(cursoTemp);

                    //Salva as alterações no contexto
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Remove um curso contexto
        /// </summary>
        /// <param name="id">Recebe o id do curso</param>
        public void Remover(int id)
        {
            try
            {


                Curso cursoTemp = BuscarPorId(id);

                if (cursoTemp == null)
                {
                    throw new Exception("Curso não encontrado");
                }
                else
                {
                    _ctx.Curso.Remove(cursoTemp);

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