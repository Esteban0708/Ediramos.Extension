using Ediramos.Extension.Aplicacion.Commands.Usuario;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ediramos.Extension.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("BuscarPrefijo")]
        public async Task<IActionResult> BuscarPorPrefijo([FromQuery] string texto)
        {
            var command = new PrefijoUserCommnand { TextoBusqueda = texto };
            var resultado = await _mediator.Send(command);
            return Ok(resultado);
        }
        [HttpGet("roles/{pegeId}")]
        public async Task<IActionResult> ObtenerRolesDeUsuario(int pegeId)
        {
            var query = new ObtenerRolesDeUsuarioQuery(pegeId);
            var resultado = await _mediator.Send(query);
            return Ok(resultado);
        }
        [HttpGet("ConsultarInformacion")]
        public async Task<IActionResult> ConsultarInformacion([FromQuery] string documento)
        {
            if (string.IsNullOrWhiteSpace(documento))
                return BadRequest("El documento es obligatorio.");

            var resultado = await _mediator.Send(new ObtenerInfoUsuarioQuery(documento));

            return Ok(new { encontrado = false, mensaje = "No se encontró información para el documento." });

        }
    }
}
