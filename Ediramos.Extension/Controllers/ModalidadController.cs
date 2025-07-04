using Ediramos.Extension.Aplicacion.Commands.Modalidad;
using Ediramos.Extension.Aplicacion.DTOs.Modalidad;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ediramos.Extension.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModalidadController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ModalidadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CrearModalidad")]
        public async Task<IActionResult> CrearModalidad([FromBody] CrearModalidadDTo dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos");
            var command = new CrearModalidadCommand(dto);
            var id = await _mediator.Send(command);
            return Ok(new { Id = id, Mensaje = "Modalidad creada con éxito" });
        }
        [HttpGet("ObtenerModalidades")]
        public async Task<IActionResult> ObtenerModalidades()
        {
            var modalidades = await _mediator.Send(new ObtenerModalidadQuery());
            return Ok(modalidades);
        }
        [HttpPut("EditarModalidad")]
        public async Task<IActionResult> EditarModalidad([FromBody] EditaModalidadDTo dto)
        {
            if (dto == null || dto.IdModalidad <= 0)
                return BadRequest("Datos inválidos");
            var command = new EditarModalidadCommand(dto);
            var result = await _mediator.Send(command);
            return Ok(new { success = result == 1, Mensaje = "Modalidad editada con éxito" });
        }

        [HttpDelete("EliminarModalidad/{id}")]
        public async Task<IActionResult> EliminarModalidad(int id)
        {
            if (id <= 0)
                return BadRequest("Id inválido");
            var command = new EliminarModalidadCommand(id);
            var result = await _mediator.Send(command);
            return Ok(new { success = result == 1, Mensaje = "Modalidad eliminada con éxito" });
        }
    }
}
