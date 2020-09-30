using Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Interfaces
{
    interface ICurtidaRepository
    {
        List<Curtida> Listar();
        Curtida BuscarPorId(int id);
        void Adicionar(Curtida curtida);
        void Remover(int id);
    }
}