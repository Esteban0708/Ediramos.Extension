using Ediramos.Extension.Aplicacion.Commands.Clase;
using Ediramos.Extension.Aplicacion.DTOs.Clase;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ediramos.Extension.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("crear")]
        public async Task<IActionResult> CrearClase([FromBody] CrearClaseDTo dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos");
            var command = new CrearClaseCommand(dto);
            var id = await _mediator.Send(command);
            return Ok(new { Id = id, Mensaje = "Clase creada con éxito" });
        }
        [HttpGet("obtener")]
        public async Task<IActionResult> ObtenerClase()
        {
            var query = new ObtenerClaseQuery();
            var clases = await _mediator.Send(query);
            return Ok(clases);
        }
    }
}
