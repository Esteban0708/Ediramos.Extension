using Ediramos.Extension.Aplicacion.Commands.UnidadMedida;
using Ediramos.Extension.Aplicacion.DTOs.UnidadMedida;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ediramos.Extension.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadMedidaController : ControllerBase
    {
        private readonly IMediator _mediator; 

        public UnidadMedidaController (IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CrearUnidadMedida")]
        public async Task<IActionResult> CrearUnidadMedida([FromBody] CrearUnidadMedidaDTo dto)
        {
            if (dto == null) 
                return BadRequest("Datos Invalidos");
            var command = new CrearUnidadMedidaCommand(dto); 
            var id = await _mediator.Send(command);
            return Ok(new {Id = id, Mensaje ="Unidad de medida creada con éxito"});
        }
        [HttpGet("ObtenerUnidadMedida")]
        public async Task<IActionResult> ObtenerUnidadMedida()
        {
            var command = new ObtenerUnidadMedidaQuery();
            var unidadMedida = await _mediator.Send(command);
            return Ok(unidadMedida);
        }
    }
}
