using Ediramos.Extension.Aplicacion.Commands.Convocatoria;
using Ediramos.Extension.Aplicacion.DTOs.Convocatoria;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ediramos.Extension.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ConvocatoriaController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ConvocatoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CrearConvocatoria")]
        public async Task<IActionResult> CrearConvocatoria([FromBody] CrearConvocatoriaDto dto)
        {
            var command = new CrearConvocatoriaCommand(dto);
            var idConvocatoria = await _mediator.Send(command);

            return Ok(new { IdConvocatoria = idConvocatoria });
        }
        [HttpGet("ObtenerConvocatoria")]
        public async Task<IActionResult> ObtenerConvocatoria()
        {
            var resultado = await _mediator.Send(new ObtenerConvocatoriaQuery());
            return Ok(resultado);
        }
   
    }
}
