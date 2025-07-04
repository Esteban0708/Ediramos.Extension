using Ediramos.Extension.Aplicacion.Commands.AreaTrabajo;
using Ediramos.Extension.Aplicacion.DTOs.AreTrabajo;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ediramos.Extension.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AreaTrabajoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AreaTrabajoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CrearAreaTrabajo")]
        public async Task<IActionResult> CrearAreaTrabajo([FromBody] CrearAreaTrabajoDTo dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos");
            var command = new CrearAreaTrabajoCommand(dto);
            var id = await _mediator.Send(command);
            return Ok(new { Id = id, Mensaje = "Área de trabajo creada con éxito" });
        }
        [HttpGet("ObtenerAreaTrabajo")]
        public async Task<IActionResult> ObtenerAreaTrabajo()
        {
            var areasTrabajo = await _mediator.Send(new ObtenerAreaTrabajoQuery ());
            return Ok(areasTrabajo);
        }
        [HttpPut("EditarAreaTrabajo")]
        public async Task<IActionResult> EditarAreaTrabajo([FromBody] EditarAreaTrabajoDTo dto)
        {
            if (dto == null || dto.IdAreaTrabajo <= 0)
                return BadRequest("Datos inválidos");
            var command = new EditarAreaTrabajoCommand(dto);
            var result = await _mediator.Send(command);
            return Ok(new { success = result == 1, Mensaje = "Área de trabajo editada con éxito" });
        }
        [HttpDelete("EliminarAreaTrabajo/{id}")]
        public async Task<IActionResult> EliminarAreaTrabajo(int id)
        {
            if (id <= 0)
                return BadRequest("Id inválido");
            var command = new EliminarAreaTrabajoCommand(id);
            var result = await _mediator.Send(command);
            return Ok(new { success = result == 1, Mensaje = "Área de trabajo eliminada con éxito" });
        }
    }
}
