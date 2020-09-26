using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edux.Domains;

namespace Edux.Interfaces
{
    interface ITurmaRepository
    {
        List<Turma> Listar();
        Turma BuscarPorId(int id);
        List<Turma> BuscarPorNome(string nome);
        void Adicionar(Turma turma);
        void Editar(Turma turma, int id);
        void Remover(int id);
    }
}
