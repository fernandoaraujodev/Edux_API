using Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Interfaces
{
    interface IRankingRepository
    {
        List<Ranking> Listar();
        List<Ranking> ListarNota();
        List<Ranking> ListarObjConcluidos();
        List<Ranking> ListarObjOcultos();
    }
}
