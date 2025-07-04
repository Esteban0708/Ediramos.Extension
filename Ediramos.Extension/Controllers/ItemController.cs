using Ediramos.Extension.Aplicacion.Commands.Convocatoria;
using Ediramos.Extension.Aplicacion.DTOs.Convocatoria;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ediramos.Extension.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("ObtenerItemEstandar")]
        public async Task<IActionResult> ObtenerItemEstandar()
        {
            var items = await _mediator.Send(new ObtenerItemEstandarQuery());
            return Ok(items);
        }

        [HttpPost("asignar-items")]
        public async Task<IActionResult> AsignarItems([FromBody] AsignarItemsConvocatoriaDto dto)
        {
            var command = new AsignarItemsConvocatoriaCommand(dto);
            var resultado = await _mediator.Send(command);

            return Ok(new { Exito = resultado });
        }
    }
}
