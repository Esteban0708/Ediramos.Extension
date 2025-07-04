using Ediramos.Extension.Aplicacion.Commands.Division;
using Ediramos.Extension.Aplicacion.Commands.Sesion;
using Ediramos.Extension.Aplicacion.DTOs.Division;
using Ediramos.Extension.Aplicacion.DTOs.Sesion;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ediramos.Extension.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DivisionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DivisionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("crear")]
        public async Task<IActionResult> CrearDivision([FromBody] CrearDivisionDTO dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos");

            var command = new CrearDivisionCommand(dto);
            var id = await _mediator.Send(command);
            return Ok(new { Id = id, Mensaje = "Sesión creada con éxito" });
        }
        [HttpGet("obtener")]
        public async Task<IActionResult> ObtenerDivision()
        {
            var command = new ObtenerDivisionQuery();
            var divisiones = await _mediator.Send(command);
            return Ok(divisiones);
        }
    }
}
