using Ediramos.Extension.Aplicacion.Commands.Grupo;
using Ediramos.Extension.Aplicacion.Commands.InscripcionGrupo;
using Ediramos.Extension.Aplicacion.DTOs.InscripcionGrupo;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Ediramos.Extension.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionGrupoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InscripcionGrupoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CrearInscripcionGrupo")]
        public async Task<IActionResult> CrearGrupo([FromBody] CrearGrupoDTo dto)
        {
            if (dto == null)
                return BadRequest(new { success = false, message = "Datos inválidos." });

            try
            {
                var command = new InscripcionGrupoCommand(dto);
                var nuevoIdGrupo = await _mediator.Send(command);

                return Ok(new
                {
                    success = true,
                    message = "Grupo creado exitosamente",
                    idGrupo = nuevoIdGrupo
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Error al crear el grupo: " + ex.Message
                });
            }
        }

        [HttpGet("ObtenerInscripciones")]
        public async Task<ActionResult<List<ObtenerInscripcionGrupoDTo>>> ObtenerInscripciones()
        {
            var resultado = await _mediator.Send(new ObtenerInscripcionGrupoQuery());
            return Ok(resultado);
        }
        [HttpGet("ObtenerObjetivosGrupo/{IdGrupo}")]
        public async Task<ActionResult<List<ObtenerObjetivoGrupoDTo>>> ObtenerObjetivosGrupo(string IdGrupo)
        {
            var result = await _mediator.Send(new ObtenerObjetivoGrupoQuery(IdGrupo));
            return Ok(result);
        }
        [HttpPost("actualizar-estado")]
        public async Task<IActionResult> ActualizarEstadoGrupo([FromBody] ActualizarEstadoGrupoInscriDto dto)
        {
            var resultado = await _mediator.Send(new ActualizarEstadoGrupoInscriCommand(dto));

            if (resultado)
                return Ok(new { mensaje = "✅ Estado del grupo actualizado correctamente." });

            return BadRequest(new { mensaje = "❌ No se pudo actualizar el estado del grupo." });
        }
        [HttpGet("historial")]
        public async Task<IActionResult> ObtenerHistorial([FromQuery] string documento)
        {
            if (string.IsNullOrWhiteSpace(documento))
                return BadRequest("Se requiere el documento.");

            var resultado = await _mediator.Send(new ObtenerHistorialGrupoQuery(documento));

            if (resultado == null || !resultado.Any())
                return NotFound("No se encontró historial para el documento proporcionado.");

            return Ok(resultado);
        }
        [HttpPut("EditarInscripcionGrupo")]
        public async Task<IActionResult> EditarGrupo(int idGrupo, [FromBody] CrearGrupoDTo dto)
        {
            if (dto == null || idGrupo <= 0)
                return BadRequest(new { success = false, message = "Datos inválidos para edición." });

            try
            {
                var command = new EditarInscripcionGrupoCommand(idGrupo, dto);
                var resultado = await _mediator.Send(command);

                if (resultado)
                    return Ok(new
                    {
                        success = true,
                        message = "Grupo editado correctamente"
                    });

                return BadRequest(new
                {
                    success = false,
                    message = "No se pudo editar el grupo"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error interno: " + ex.Message
                });
            }
        }


    }
}
