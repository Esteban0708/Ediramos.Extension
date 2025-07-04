using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Usuario;
using Ediramos.Extension.Aplicacion.DTOs.Sesion;
using Ediramos.Extension.Aplicacion.DTOs.Usuario;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Usuario
{
    public class LoginCommandHandler  : IRequestHandler <LoginCommand, UsuarioDTO>
    {
        private readonly IUsuarioRepository _repo;

        public LoginCommandHandler(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public async Task<UsuarioDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _repo.LoginAsycn(request.Correo, request.Contraseña);

            if (usuario == null)
            {
                return null;
            }
            await _repo.RegistrarUsuarioAsync(usuario);

            return new UsuarioDTO
            {
                PEGE_ID = usuario.Pege_id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Documento = usuario.Documento,
                Telefono = usuario.Telefono,
                Estatus = usuario.Estatus.Select(e => new EstadoPersonaDTO
                {
                    Estatus = e.Estatus
                }).ToList()
            };
        }
    }
    
}
