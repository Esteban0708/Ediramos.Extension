using Ediramos.Extension.Aplicacion.Commands.Proyecto;
using Ediramos.Extension.Aplicacion.DTOs.Proyecto;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ediramos.Extension.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProyectosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("crearProyecto")]
        public async Task<IActionResult> CrearProyecto([FromBody] ProyectoCompletoDTO dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest("Datos del proyecto incompletos.");

                var command = new CrearProyectoCommand(dto);
                int idProyecto = await _mediator.Send(command);

                return Ok(new
                {
                    Mensaje = "Proyecto creado correctamente",
                    IdProyecto = idProyecto
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Mensaje = "Error al crear el proyecto",
                    Detalle = ex.Message
                });
            }
        }
        [HttpGet("obtenerProyectosUsuario/{documento}")]
        public async Task<IActionResult> ObtenerProyectosUsuario(string documento)
        {
            try
            {
                var query = new ObtenerProyectosUsuarioQuery(documento);
                var resultado = await _mediator.Send(query);

                if (resultado == null || resultado.Proyectos.Count == 0)
                    return NotFound("No se encontraron proyectos para el usuario.");

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Mensaje = "Error al obtener los proyectos del usuario",
                    Detalle = ex.Message
                });
            }
        }
        [HttpGet("obtenerIndicadoresProyecto/{idProyecto}")]
        public async Task<IActionResult> ObtenerIndicadoresProyecto(int idProyecto)
        {
            try
            {
                var query = new ObtenerIndicadoresProyectoQuery(idProyecto);
                var resultado = await _mediator.Send(query);

                if (resultado == null)
                    return NotFound("No se encontraron indicadores para el proyecto.");

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Mensaje = "Error al obtener los indicadores del proyecto",
                    Detalle = ex.Message
                });
            }
        }
        [HttpGet("obtenerCronogramaProyecto/{idProyecto}")]
        public async Task<IActionResult> ObtenerCronogramaProyecto(int idProyecto)
        {
            try
            {
                var query = new CronogramaPresupuestoQuery(idProyecto);
                var resultado = await _mediator.Send(query);

                if (resultado == null)
                    return NotFound("No se encontro Cronograma para el proyecto.");

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Mensaje = "Error al obtener los indicadores del proyecto",
                    Detalle = ex.Message
                });
            }
        }
    }
}
