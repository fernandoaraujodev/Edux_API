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
    public class RankingNotasController : ControllerBase
    {
        private readonly IRankingRepository _rankingCurtidaRepository;

        public RankingNotasController()
        {
            _rankingCurtidaRepository = new RankingRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var rankingCurtida = _rankingCurtidaRepository.ListarNota();

                if (rankingCurtida.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = rankingCurtida.Count,
                    data = rankingCurtida

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
