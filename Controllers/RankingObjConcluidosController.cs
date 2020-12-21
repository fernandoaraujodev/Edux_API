using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edux.Interfaces;
using Edux.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingObjConcluidosController : ControllerBase
    {
        private readonly IRankingRepository _rankingObjConcluidosRepository;

        public RankingObjConcluidosController()
        {
            _rankingObjConcluidosRepository = new RankingRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var rankingObjConcluidos = _rankingObjConcluidosRepository.ListarObjConcluidos();

                if (rankingObjConcluidos.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = rankingObjConcluidos.Count,
                    data = rankingObjConcluidos

                });
            }
            catch (Exception)
            {

                return BadRequest(new
                {
                    StatusCode = 400,
                    error = "Ocorreu um erro no endpoint Get/perfil, enviei um e-mail para email@email.com informando"
                });
            }
        }
    }
}
