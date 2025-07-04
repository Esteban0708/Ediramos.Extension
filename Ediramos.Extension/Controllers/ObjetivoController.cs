using Ediramos.Extension.Aplicacion.Commands.Objetivo;
using Ediramos.Extension.Aplicacion.DTOs.Objetivo;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ediramos.Extension.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObjetivoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ObjetivoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("crearObjetivo")]
        public async Task<IActionResult> CrearObjetivo([FromBody] CrearObjetivoDTO dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos");

            var command = new CrearObjetivoCommand(dto);
            var id = await _mediator.Send(command);

            return Ok(new { Id = id, Mensaje = "Objetivo creado con éxito" });
        }

        [HttpGet("obtenerObjetivo")]
        public async Task<IActionResult> ObtenerObjetivos()
        {
            var objetivos = await _mediator.Send(new ObtenerObjetivosQuery());
            return Ok(objetivos);
        }

        [HttpPut("editarObjetivo")]
        public async Task<IActionResult> EditarObjetivo([FromBody] EditarObjetivoDto dto)
        {
            if (dto == null || dto.IdObjetivo <= 0)
                return BadRequest("Datos inválidos");

            var command = new EditarObjetivoCommand(dto);
            var result = await _mediator.Send(command);

            return Ok(new { success = result == 1, Mensaje = "Objetivo editado con éxito" });
        }

        [HttpDelete("eliminarObjetivo/{id}")]
        public async Task<IActionResult> EliminarObjetivo(int id)
        {
            if (id <= 0)
                return BadRequest("Id inválido");

            var command = new EliminarObjetivoCommand(id);
            var result = await _mediator.Send(command);

            return Ok(new { success = result == 1, Mensaje = "Objetivo eliminado con éxito" });
        }

    }
}
