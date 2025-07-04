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
    public class DesactivarUsuarioRolHandler : IRequestHandler<DesactivarUsuarioRolCommand, bool>
    {
        private readonly IRolRepository _rolRepository;

        public DesactivarUsuarioRolHandler(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public async Task<bool> Handle(DesactivarUsuarioRolCommand request, CancellationToken cancellationToken)
        {
            return await _rolRepository.DesactivarUsuarioRolAsync(request.PegeId, request.IdRol);
        }
    }

}
