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
    public class RankingObjOcultosController : ControllerBase
    {
        private readonly IRankingRepository _rankingObjOcultosRepository;

        public RankingObjOcultosController()
        {
            _rankingObjOcultosRepository = new RankingRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var rankingObjOcultos = _rankingObjOcultosRepository.ListarObjOcultos();

                if (rankingObjOcultos.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = rankingObjOcultos.Count,
                    data = rankingObjOcultos

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
