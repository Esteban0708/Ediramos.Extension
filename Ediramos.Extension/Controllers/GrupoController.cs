using Ediramos.Extension.Aplicacion.Commands.Grupo;
using Ediramos.Extension.Aplicacion.DTOs.Grupo;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ediramos.Extension.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GrupoController : Controller
    {
        private readonly IMediator _mediator; 
        public GrupoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("crear")]
        public async Task<IActionResult> CrearGrupo([FromBody] CrearGrupoDTO dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos");
            var command = new CrearGrupoCommand(dto);
            var id = await _mediator.Send(command);
            return Ok(new { Id = id, Mensaje = "Grupo creado con éxito" });
        }
        [HttpGet("obtener")]
        public async Task<IActionResult> ObtenerGrupo()
        {
            var command = new ObtenerGrupoQuery();
            var grupos = await _mediator.Send(command);
            return Ok(grupos);
        }
    }
}
