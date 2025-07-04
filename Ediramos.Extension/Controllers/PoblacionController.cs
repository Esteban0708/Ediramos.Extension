using Ediramos.Extension.Aplicacion.Commands.PoblacionCondicion;
using Ediramos.Extension.Aplicacion.DTOs.PoblacionCondicion;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ediramos.Extension.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoblacionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PoblacionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("crearPoblacion")]
        public async Task<IActionResult> CrearPoblacion([FromBody] CrearPoblacionDTo dto)
        {
            if (dto == null)
                return BadRequest("los Datos no pueden estar vacío");
            var command = new CrearPoblacionCommand(dto);
            var id = await _mediator.Send(command);
            return Ok(new { Id = id, Mensaje = "Población creada con éxito" });
        }
        [HttpGet("obtenerPoblacion")]
        public async Task<IActionResult> ObtenerPoblaciones()
        {
            var poblaciones = await _mediator.Send(new ObtenerPoblacionQuery());
            return Ok(poblaciones);
        }
        [HttpPut("editarPoblacion")]
        public async Task<IActionResult> EditarPoblacion([FromBody] EditarPoblacionDTo dto)
        {
            if (dto == null || dto.IdPoblacion <= 0 || string.IsNullOrEmpty(dto.Nombre))
                return BadRequest("Datos inválidos");
            var command = new EditarPoblacionCommand(dto);
            var result = await _mediator.Send(command);
            return Ok(new { success = result == 1, Mensaje = "Población editada con éxito" });
        }
        [HttpDelete("eliminarPoblacion/{id}")]
        public async Task<IActionResult> EliminarPoblacion(int id)
        {
            if (id <= 0)
                return BadRequest("Id inválido");
            var command = new EliminarPoblacionCommand(id);
            var result = await _mediator.Send(command);
            return Ok(new { success = result == 1, Mensaje = "Población eliminada con éxito" });

        }
    }
}
