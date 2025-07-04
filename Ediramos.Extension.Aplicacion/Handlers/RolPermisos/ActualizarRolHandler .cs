using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Rol;
using Ediramos.Extension.Aplicacion.DTOs.RolPermisos;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.RolPermisos
{
    public class ActualizarRolHandler : IRequestHandler<ActualizarRolCommand, bool>
    {
        public readonly IRolRepository _rolRepository;
        public readonly IPermisosRepository _permisosRepository;

        public ActualizarRolHandler(IRolRepository rolRepository, IPermisosRepository permisosRepository)
        {
            _rolRepository = rolRepository;
            _permisosRepository = permisosRepository;
        }
        public async Task<bool> Handle(ActualizarRolCommand rolcommand, CancellationToken cancellationToken)
        {
            var result = await _rolRepository.ActualizarRolAsync(
               rolcommand.DTO.IdRol,
               rolcommand.DTO.NombreRol,
               rolcommand.DTO.ColorHex,
               rolcommand.DTO.Permisos
           );

            return result;

        }
    }
}
