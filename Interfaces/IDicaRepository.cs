using Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Interfaces
{
    interface IDicaRepository
    {

        List<Dica> Listar();
        Dica BuscarPorId(int id);
        void Adicionar(Dica dica);
        void Editar(Dica dica, int id);
        void Remover(int id);

    }
}