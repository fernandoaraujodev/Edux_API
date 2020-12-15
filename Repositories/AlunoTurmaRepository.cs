using Edux.Contexts;
using Edux.Domains;
using Edux.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Edux.Repositories
{
    public class AlunoTurmaRepository : IAlunoTurmaRepository
    {
        private readonly EduxContext _ctx;
        public AlunoTurmaRepository()
        {
            _ctx = new EduxContext();
        }

        public void Adicionar(AlunoTurma alunoTurma)
        {
            try
            {
                // Adiciona alunoturma
                _ctx.Add(alunoTurma);

                //Salvar alterações
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public AlunoTurma BuscarPorId(int id)
        {
            try
            {
                //procura o id
                return _ctx.AlunoTurma.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(int id, AlunoTurma alunoTurma)
        {
            try
            {
                //Busca AlunoTurma pelo id
                AlunoTurma alunoTurmaTemp = BuscarPorId(id);

                //Edita Matricula
                alunoTurmaTemp.Matricula = alunoTurma.Matricula;

                //Altera aluno turma no contexto
                _ctx.AlunoTurma.Update(alunoTurmaTemp);
                //Salva o contexo
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<AlunoTurma> Listar()
        {
            try
            {
                //Coloca o alunoturma em uma lista
                //List<AlunoTurma> alunoTurma = _ctx.AlunoTurma
                //    .Include(y => y.IdUsuarioNavigation)
                //   .Include(z => z.IdTurmaNavigation)
                //   .ToList();
                return _ctx.AlunoTurma.Include(y => y.IdUsuarioNavigation).Include(z => z.IdTurmaNavigation).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            };
        }

        public void Remover(int id)
        {
            try
            {
                //Busca alunoturma pelo id
                AlunoTurma alunoTurmaTemp = BuscarPorId(id);

                //Verifica se alunoTurma existe
                //Caso não existe gera um exception
                if (alunoTurmaTemp == null)
                    throw new Exception("alunoturma não encontrado");

                //Remove o alunoturma do dbSet
                _ctx.AlunoTurma.Remove(alunoTurmaTemp);
                //Salva as alterações do contexto
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
