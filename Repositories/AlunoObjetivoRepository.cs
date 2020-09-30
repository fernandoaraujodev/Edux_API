using Edux.Contexts;
using Edux.Domains;
using Edux.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Edux.Repositories
{
    public class AlunoObjetivoRepository : IAlunoObjetivoRepository
    {

        private readonly EduxContext _ctx;

        public AlunoObjetivoRepository()
        {
            _ctx = new EduxContext();
        }


        /// <summary>
        /// Método para adicionar um novo objetivo para um aluno
        /// </summary>
        /// <param name="alunoObjetivo">Objeto alunoObjetivo</param>
        public void Adicionar(AlunoObjetivo alunoObjetivo)
        {

            try
            {
                // O contexto recebe o objeto inst do método
                _ctx.Add(alunoObjetivo);

                //Salva as alterações no banco de dados Edux
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Método que busca pelo Id todos os dados da tabela AlunoObjetivo
        /// </summary>
        /// <param name="id">Id de AlunoObjetivo</param>
        /// <returns>Objeto AlunoObjetivo</returns>
        public AlunoObjetivo BuscarPorId(int id)
        {
            try
            {
                //Contexto é chamado com a instrução de encontrar na tabela AlunoObjetivo com o id passado
                return _ctx.AlunoObjetivo
                    .Include(z => z.IdObjetivoNavigation)
                    .Include(x => x.IdAlunoTurmaNavigation)
                    .FirstOrDefault(x => x.IdAlunoObjetivo == id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Método para editar um objeto AlunoObjetivo
        /// </summary>
        /// <param name="alunoObjetivo">Objeto AlunoObjetivo</param>
        /// <param name="id">Id do AlunoObjetivo</param>
        public void Editar(AlunoObjetivo alunoObjetivo, int id)
        {
            try
            {

                //Usa o método BuscarPorId para verificar a existência do AlunoObjetivo informado
                AlunoObjetivo alunoObjetivoTemp = BuscarPorId(id);

                //Se ela não existir é informado que o AlunoObjetivo não foi encontrado
                if (alunoObjetivoTemp == null)
                {
                    throw new Exception("Objetivo do aluno não encontrado");
                }
                else
                {
                    //Caso contrário salva todas as alterações no objeto alunoObjetivoTemp
                    //Para posteiormente salvá-las no contexto
                    alunoObjetivoTemp.Nota = alunoObjetivo.Nota;
                    alunoObjetivoTemp.IdAlunoTurma = alunoObjetivo.IdAlunoTurma;
                    alunoObjetivoTemp.IdObjetivo = alunoObjetivo.IdObjetivo;

                    //Atualiza o AlunoObjetivo com o id informado
                    _ctx.AlunoObjetivo.Update(alunoObjetivoTemp);

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
        /// Método para listar todos os dados da tabela AlunoObjetivo
        /// </summary>
        /// <returns>Lista com todos os dados da tabela AlunoObjetivo</returns>
        public List<AlunoObjetivo> Listar()
        {
            try
            {
                return _ctx.AlunoObjetivo
                                .Include(i => i.IdAlunoTurmaNavigation)
                                .Include(y => y.IdObjetivoNavigation)
                                .ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para remover um AlunoObjetivo
        /// </summary>
        /// <param name="id">Id de AlunoObjetivo</param>
        public void Remover(int id)
        {
            try
            {

                //Usa o método BuscarPorId para verificar a existência do AlunoObjetivo
                AlunoObjetivo alunoObjetivoTemp = BuscarPorId(id);

                //Se ela não existir é informado que a instituição não foi encontrada
                if (alunoObjetivoTemp == null)
                {
                    throw new Exception("Objetivo do aluno não encontrado");
                }
                else
                {
                    //Remove a instituição informada do contexto
                    _ctx.AlunoObjetivo.Remove(alunoObjetivoTemp);

                    //Salva todas as alterações
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}