using Ediramos.Extension.Aplicacion.Commands.Linea;
using Ediramos.Extension.Aplicacion.DTOs.Linea;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ediramos.Extension.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LineaProfundizacionController : ControllerBase
    {
        private readonly IMediator mediator; 

        public LineaProfundizacionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("CrearLinea")]
        public async Task<IActionResult> CrearLinea([FromBody] CrearLineaDTo dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos");
            var command = new CrearLineaCommand(dto);
            var id = await mediator.Send(command);
            return Ok(new { Id = id, Mensaje = "Línea de profundización creada con éxito" });
        }

        [HttpGet("ObtenerLineas")]
        public async Task<IActionResult> ObtenerLineas()
        {
            var lineas = await mediator.Send(new ObtenerLineasQuery());
            return Ok(lineas);
        }

        [HttpPut("EditarLinea")]
        public async Task<IActionResult> EditarLinea([FromBody] EditarLineaDTo dto)
        {
            if(dto == null || dto.IdLineaProfundizacion <= 0)
                return BadRequest("Datos inválidos");

            var command = new EditarLineaCommand(dto);
            var result = await mediator.Send(command);

            return Ok(new { success = result == 1, Mensaje = "Linea editada con éxito"});
        }

        [HttpDelete("EliminarLinea/{id}")]
        public async Task<IActionResult> EliminarLinea(int id)
        {

            if (id <= 0)
                return BadRequest("Id inválido");

            var command = new EliminarLineaCommand(id);
            var result = await mediator.Send(command);

            return Ok(new { success = result == 1, Mensaje = "Linea eliminada con éxito" });
        }
    }
}
