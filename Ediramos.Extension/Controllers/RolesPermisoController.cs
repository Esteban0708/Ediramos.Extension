using Ediramos.Extension.Aplicacion.Commands.Rol;
using Ediramos.Extension.Aplicacion.DTOs.RolPermisos;
using Ediramos.Extension.Aplicacion.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Ediramos.Extension.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesPermisoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesPermisoController(IMediator mediator) { 
            
            _mediator = mediator;
        }
        [HttpGet("obtenerPermisos")]
        public async Task<IActionResult> ObtenerPermisos()
        {
            var permisos = await _mediator.Send(new ObtenerPermisosQuery());
            return Ok(permisos);
        }

        [HttpPost("CrearRol")]
        public async Task<IActionResult> CrearRol([FromBody] CrearRolDTo dto)
        {
            var command = new CrearRolCommand
            {
                Nombre = dto.Nombre,
                ColorHex = dto.ColorHex,
                Permisos = dto.Permisos
            };

            var resultados = await _mediator.Send(command);
            return Ok(resultados);

        }

        [HttpGet("obtenerPermisoRol")]
        public async Task<IActionResult> ObtenerPermisoRol()
        {
            var permisoRol = await _mediator.Send(new ObtenerPermisoRolQuery());
            return Ok(permisoRol);
        }
        [HttpPut("ActualizarRol")]
        public async Task<IActionResult> ActualizarRol([FromBody] EditarRolPermisoDTo dto)
        {
            var command = new ActualizarRolCommand(dto);
            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok(new { mensaje = "Rol actualizado correctamente." });
            }
            return BadRequest(new { mensaje = "No se pudo actualizar el rol." });
        }

        [HttpDelete("EliminarRol/{idRol}")]
        public async Task<IActionResult> EliminarRol(int idRol)
        {
            if (idRol <= 0)
                return BadRequest("Id inválido");

            var command = new EliminarRolCommand(idRol);

            try
            {
                var result = await _mediator.Send(command);
                return Ok(new { success = result == 1, Mensaje = "Rol eliminado con éxito" });
            }
            catch (SqlException ex) when (ex.Message.Contains("No se puede eliminar el rol"))
            {
                return BadRequest(new { success = false, Mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, Mensaje = "Error interno del servidor" });
            }
        }
        [HttpGet("contarUsuariosPorRol")]
        public async Task<IActionResult> ContarUsuariosPorRol()
        {
            var resultado = await _mediator.Send(new CantidadUsuarioRolQuery());
            return Ok(resultado);
        }
        [HttpPost("asignarRol")]
        public async Task<IActionResult> AsignarRol([FromBody] AsignarRolUsuarioDto dto)
        {
            var command = new AsignarRolUsuarioCommand(dto);
            var resultado = await _mediator.Send(command);
            return Ok(new { mensaje = "Rol asignado correctamente" });
        }
        [HttpGet("usuarios-por-rol/{idRol}")]
        public async Task<IActionResult> ObtenerUsuariosPorRol(int idRol)
        {
            var usuarios = await _mediator.Send(new ObtenerUsuariosPorRolQuery(idRol));
            return Ok(usuarios);
        }
        [HttpPut("desactivarUsuarioRol")]
        public async Task<IActionResult> DesactivarUsuarioRol([FromBody] DesactivarUsuarioRolDto dto)
        {
            var resultado = await _mediator.Send(new DesactivarUsuarioRolCommand(dto));
            return resultado
                ? Ok(new { mensaje = "Rol desactivado correctamente." })
                : BadRequest(new { mensaje = "No se pudo desactivar el rol." });
        }


    }
}
