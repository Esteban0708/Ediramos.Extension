using Ediramos.Extension.Aplicacion.Commands.CicloVida;
using Ediramos.Extension.Aplicacion.DTOs.CicloVida;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ediramos.Extension.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CicloVidaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CicloVidaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CrearCicloVida")]
        public async Task<IActionResult> CrearCicloVida([FromBody] CrearCicloVidaDTo dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos");
            var command = new CrearCicloVidaCommand(dto);
            var id = await _mediator.Send(command);
            return Ok(new { Id = id, Mensaje = "Ciclo de vida creado con éxito" });
        }
        [HttpGet("ObtenerCicloVida")]
        public async Task<IActionResult> ObtenerCiclosVida()
        {
            var ciclosVida = await _mediator.Send(new ObtenerCicloVidaQuery());
            return Ok(ciclosVida);
        }
        [HttpPut("EditarCicloVida")]
        public async Task<IActionResult> EditarCicloVida([FromBody] EditarCicloVidaDTo dto)
        {
            if (dto == null || dto.IdCicloVida <= 0 || string.IsNullOrWhiteSpace(dto.Nombre))
                return BadRequest("Datos inválidos");
            var command = new EditarCicloVidaCommand(dto);
            var result = await _mediator.Send(command);
            return Ok(new { success = result == 1, Mensaje = "Ciclo de vida editado con éxito" });
        }
        [HttpDelete("EliminarCicloVida/{id}")]
        public async Task<IActionResult> EliminarCicloVida(int id)
        {
            if (id <= 0)
                return BadRequest("Id inválido");
            var command = new EliminarCicloVidaCommand(id);
            var result = await _mediator.Send(command);
            return Ok(new { success = result == 1, Mensaje = "Ciclo de vida eliminado con éxito" });
        }
    }
}
