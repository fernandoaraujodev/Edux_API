using Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Interfaces
{
    interface IObjetivoRepository
    {
        List<Objetivo> Listar();

        Objetivo BuscarPorId(int id);

        void Adicionar(Objetivo obj);

        void Editar(int id, Objetivo obj);

        void Remover(int id);
    }
}
