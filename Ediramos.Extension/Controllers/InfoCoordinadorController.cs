using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ediramos.Extension.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoCoordinadorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InfoCoordinadorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ObtenerInfoCoordinador/{documento}")]
        public async Task<IActionResult> ObtenerInfoCoordinador(string documento)
        {
            var resultado = await _mediator.Send(new ObtenerInfoCoordinadorQuery(documento));
            if (resultado == null || !resultado.Any())
            {
                return NotFound("No se encontraron datos del coordinador.");
            }
            return Ok(resultado);
        }
        [HttpGet("ObtenerSemestre/{documento}")]
        public async Task<IActionResult> ObtenerSemestre(string documento)
        {
            var resultado = await _mediator.Send(new ObtenerSemestreQuery(documento));
            if (resultado == null || !resultado.Any())
            {
                return NotFound("No se encontraron datos del semestre.");
            }
            return Ok(resultado);

        }
    }
}
