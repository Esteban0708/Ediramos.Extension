using Ediramos.Extension.Aplicacion.Commands.Usuario;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace Ediramos.Extension.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAngularApp")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("LoginUsuario")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

            var usuario = await _mediator.Send(command);
            if (usuario == null)
            {
                return Unauthorized("Correo o contraseña inválidos");
            }
            Response.Cookies.Append("Nombre", usuario.Nombre);
            Response.Cookies.Append("Correo", usuario.Correo);
            Response.Cookies.Append("Telefono", usuario.Telefono);
            Response.Cookies.Append("Documento", usuario.Documento);

            return Ok(new
            {
                mensaje = "Inicio de sesión exitoso",
                usuario
            });
        }
        [HttpGet("usuario")]
        public IActionResult ObtenerUsuario()
        {
            var correo = Request.Cookies["Correo"];
            if (correo == null)
                return Unauthorized("No hay sesión activa.");

            return Ok(new
            {
                Correo = correo,
                Nombre = Request.Cookies["Nombre"],
                Documento = Request.Cookies["Documento"],
                Telefono = Request.Cookies["Telefono"],
            });
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("Correo");
            Response.Cookies.Delete("Nombre");
            Response.Cookies.Delete("Telefono");
            Response.Cookies.Delete("Documento");
                
            return Ok(new
            {
                mensaje = "Sesión cerrada correctamente"
            });
        }
    }
}
