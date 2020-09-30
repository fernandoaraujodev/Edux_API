using Edux.Contexts;
using Edux.Domains;
using Edux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly EduxContext _context = new EduxContext();

        public void Adicionar(Curso curso)
        {
            throw new NotImplementedException();
        }

        public Curso BuscarPorId(Guid id)
        {
            try
            {
                return _context.Curso.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Curso> BuscarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public void Editar(Curso curso)
        {
            throw new NotImplementedException();
        }

        public List<Curso> Listar()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}