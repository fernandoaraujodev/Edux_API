using Edux.Domains;
using System.Collections.Generic;

namespace Edux.Interfaces
{
    interface IAlunoTurmaRepository
    {
        List<AlunoTurma> Listar();
        AlunoTurma BuscarPorId(int id);
        void Adicionar(AlunoTurma alunoTurma);
        void Remover(int id);
        void Editar(int id, AlunoTurma alunoTurma);
    }
}
