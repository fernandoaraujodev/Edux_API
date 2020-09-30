using Edux.Domains;
using System;
using System.Collections.Generic;

namespace Edux.Interfaces
{
    interface IPerfiIRepository
    {
        List<Perfil> Listar();
        Perfil BuscarPorId(int id);
        void Adicionar(Perfil perfil);
        void Remover(int id);
        void Editar(int id, Perfil perfil);
    }
}