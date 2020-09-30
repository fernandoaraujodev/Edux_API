using Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Interfaces
{
    interface IAlunoObjetivoRepository
    {
        List<AlunoObjetivo> Listar();
        AlunoObjetivo BuscarPorId(int id);
        void Adicionar(AlunoObjetivo alunoObjetivo);
        void Editar(AlunoObjetivo alunoObjetivo, int id);
        void Remover(int id);
    }
}