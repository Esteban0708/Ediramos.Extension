using Ediramos.Extension.Aplicacion.Commands.Proyecto;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ediramos.Extension.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoAnexoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProyectoAnexoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromForm] CrearProyectoAnexoCommand command)
        {
            var resultado = await _mediator.Send(command);
            return Ok(new { mensaje = "Guardado correctamente" });
        }
        [HttpGet("anexos/{idProyecto}")]
        public async Task<IActionResult> ObtenerAnexos(string idProyecto)
        {
            var resultado = await _mediator.Send(new ObtenerAnexosProyectoQuery(idProyecto));
            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

    }
}
