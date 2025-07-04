using Ediramos.Extension.Aplicacion.Commands.PoblacionGrupo;
using Ediramos.Extension.Aplicacion.DTOs.PoblacionGrupo;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ediramos.Extension.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoblacionGrupoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PoblacionGrupoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CrearPoblacionGrupo")]
        public async Task<IActionResult> CrearPoblacionGrupo([FromBody] CrearPoblacionGrupoDto dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos");
            var command = new CrearPoblacionGrupoCommand(dto);
            var id = await _mediator.Send(command);
            return Ok(new { Id = id, Mensaje = "Población/Grupo creado con éxito" });
        }
        [HttpGet("ObtenerPoblacionGrupo")]
        public async Task<IActionResult> ObtenerPoblacionGrupo()
        {
            var poblacionesGrupos = await _mediator.Send(new ObtenerPoblacionGrupoQuery());
            return Ok(poblacionesGrupos);
        }
        [HttpPut("EditarPoblacionGrupo")]
        public async Task<IActionResult> EditarPoblacionGrupo([FromBody] EditarPoblacionGrupoDTo dto)
        {
            if (dto == null || dto.IdGrupo <= 0)
                return BadRequest("Datos inválidos");
            var command = new EditarPoblacionGrupoCommand(dto);
            var result = await _mediator.Send(command);
            return Ok(new { success = result == 1, Mensaje = "Población/Grupo editado con éxito" });
        }
        [HttpDelete("EliminarPoblacionGrupo/{id}")]
        public async Task<IActionResult> EliminarPoblacionGrupo(int id)
        {
            if (id <= 0)
                return BadRequest("Id inválido");
            var command = new EliminarPoblacionGrupoCommand(id);
            var result = await _mediator.Send(command);
            return Ok(new { success = result == 1, Mensaje = "Población/Grupo eliminado con éxito" });
        }
    }
}
