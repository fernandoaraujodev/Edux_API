using Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Interfaces
{
    interface IInstituicaoRepository
    {
        List<Instituicao> Listar();
        Instituicao BuscarPorId(int id);
        List<Instituicao> BuscarPorNome(string nome);
        void Adicionar(Instituicao inst);
        void Editar(Instituicao inst, int id);
        void Remover(int id);

    }
}
