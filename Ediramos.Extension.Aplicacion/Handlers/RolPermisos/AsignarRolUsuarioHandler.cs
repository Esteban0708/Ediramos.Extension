using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Rol;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.RolPermisos
{
    public class AsignarRolUsuarioHandler : IRequestHandler<AsignarRolUsuarioCommand>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public AsignarRolUsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<Unit> Handle(AsignarRolUsuarioCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;
            await _usuarioRepository.AsignarRolUsuarioAsync(dto.PegeId, dto.NombreCompleto, dto.DocumentoIdentidad, dto.IdRol);
            return Unit.Value;
        }
    }
}
