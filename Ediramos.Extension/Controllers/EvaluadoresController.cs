using Ediramos.Extension.Aplicacion.Commands.Evaluador;
using Ediramos.Extension.Aplicacion.DTOs.Evaluador;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ediramos.Extension.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluadoresController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EvaluadoresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AsignarEvaluadores")]
        public async Task<IActionResult> AsignarEvaluadores([FromBody] AsignarEvaluadorDTo evaluador)
        {
            try
            {
                var resultado = await _mediator.Send(new AsignarEvaluadorCommand(evaluador));

                return Ok(new { message = "Evaluador asignado correctamente." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch
            {
                return BadRequest(new { message = "Error al asignar el evaluador." });
            }
        }

        [HttpGet("EvaluadoresPorProyecto/{idProyecto}")]
        public async Task<IActionResult> ObtenerEvaluadoresPorProyecto(int idProyecto)
        {
            var resultado = await _mediator.Send(new ObtenerEvaluadoresPorProyectoQuery(idProyecto));
            return Ok(resultado);
        }
    }
}
