using Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Interfaces
{
    interface ICursoRepository
    {
     
        List<Curso> Listar();

        Curso BuscarPorId(int id);

        void Adicionar(Curso curso);

        List<Curso> BuscarPorNome(string titulo);

        void Editar(Curso curso, int id);

        void Remover(int id);



    }
}