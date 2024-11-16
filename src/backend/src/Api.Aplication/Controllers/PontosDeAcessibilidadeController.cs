

using System.Net;
using Infra.UPX4.Domain.Dto;
using Infra.UPX4.Domain.Interfaces.Repositories;
using Infra.UPX4.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;


namespace Api.UPX4.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PontosDeAcessibilidadeController : ControllerBase
    {
        private readonly IPontoDeAcessibilidadeService _pontoService;


        public PontosDeAcessibilidadeController(IPontoDeAcessibilidadeService pontoService)
        {
            _pontoService = pontoService;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Salvar([FromBody] PontoDeAcessibilidadeDto pontodeacessibilidade)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var result = await _pontoService.Salvar(pontodeacessibilidade);


                return Ok(result);



            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }



        [HttpGet]
        public async Task<IActionResult> GetPontosDeAcessibilidade(
        [FromQuery] double north,
        [FromQuery] double south,
        [FromQuery] double east,
        [FromQuery] double west)
        {
            var pontos = await _pontoService.GetPontosDentroDosLimitesAsync(north, south, east, west);

            if (pontos == null || pontos.Count == 0)
            {
                return NotFound("Nenhum ponto de acessibilidade encontrado.");
            }

            return Ok(pontos);
        }
    }




}