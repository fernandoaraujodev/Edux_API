using Edux.Contexts;
using Edux.Domains;
using Edux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Repositories
{
    public class DicaRepository : IDicaRepository
    {
        private readonly EduxContext _context = new EduxContext();

        public void Adicionar(Dica dica)
        {
            throw new NotImplementedException();
        }

        public Dica BuscarPorId(Guid id)
        {
            try
            {
                return _context.Dica.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Dica> BuscarPorNome(string texto)
        {
            throw new NotImplementedException();
        }

        public void Editar(Dica dica)
        {
            throw new NotImplementedException();
        }

        public List<Dica> Listar()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}