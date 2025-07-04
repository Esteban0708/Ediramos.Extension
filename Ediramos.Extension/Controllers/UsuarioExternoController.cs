using Ediramos.Extension.Aplicacion.Commands.UsuarioExterno;
using Ediramos.Extension.Aplicacion.DTOs.UsuarioExterno;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ediramos.Extension.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioExternoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuarioExternoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CrearUsuarioExterno")]
        public async Task<IActionResult> CrearUsuarioExterno([FromBody] CrearUsuarioExternoDTo dto)
        {
            if (dto == null)
            {
                return BadRequest("El comando no puede ser nulo.");
            }
            var command = new CrearUsuarioExternoCommand(dto);
            var id = await _mediator.Send(command);
            return Ok(new { Id = id, Mensaje = "Usuario externo creado con éxito" });
        }
        [HttpGet("ObtenerUsuariosExternos")]
        public async Task<IActionResult> ObtenerUsuariosExternos([FromQuery] string documentoParcial)
        {
            var query = new ObtenerUsuarioExternoQuery(documentoParcial);
            var resultado = await _mediator.Send(query);
            return Ok(resultado);
        }
    }
}
