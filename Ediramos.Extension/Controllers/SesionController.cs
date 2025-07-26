using Ediramos.Extension.Aplicacion.Commands.Division;
using Ediramos.Extension.Aplicacion.Commands.Sesion;
using Ediramos.Extension.Aplicacion.DTOs.Sesion;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ediramos.Extension.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SesionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SesionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("crear")]
        public async Task<IActionResult> CrearSesion([FromBody] CrearSesionDTO dto)
        {
            if(dto ==null)
                return BadRequest("Datos inválidos");

            var command = new CrearSesionCommand(dto);
            var id = await _mediator.Send(command);
            return Ok(new { Id = id, Mensaje = "Sección creada con éxito" });
        }
        [HttpGet("obtener")]
        public async Task<IActionResult> ObtenerSesiones()
        {
            var command = new ObtenerSesionQuery();
            var sesiones = await _mediator.Send(command);
            return Ok(sesiones);
        }
        [HttpDelete("EliminarSesion/{id}")]
        public async Task<IActionResult> EliminarSesion(int id)
        {
            var result = await _mediator.Send(new EliminarSesionCommand(id));

            if (result == 1)
                return Ok(new { mensaje = "Sección eliminada correctamente" });

            return BadRequest("No se pudo eleiminar la Division");
        }
    }
}
