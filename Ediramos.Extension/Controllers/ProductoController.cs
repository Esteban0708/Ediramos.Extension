using Ediramos.Extension.Aplicacion.Commands.Producto;
using Ediramos.Extension.Aplicacion.DTOs.Producto;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ediramos.Extension.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> CrearProducto([FromBody] CrearProductoDTo dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos");
            var command = new CrearProductoCommand(dto);
            var id = await _mediator.Send(command);
            return Ok(new { Id = id, Mensaje = "Producto creado con éxito" });
        }
        [HttpGet("obtener")]
        public async Task<IActionResult> ObtenerProducto()
        {
            var query = new ObtenerProductoQuery();
            var productos = await _mediator.Send(query);
            return Ok(productos);
        }
    }
}
