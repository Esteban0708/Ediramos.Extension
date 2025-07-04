using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Entidades;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.RolPermisos
{
    public class ObtenerUsuariosPorRolHandler : IRequestHandler<ObtenerUsuariosPorRolQuery, List<ObtenerUsuarioRol>>
    {
        private readonly IRolRepository _rolRepository;

        public ObtenerUsuariosPorRolHandler(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public async Task<List<ObtenerUsuarioRol>> Handle(ObtenerUsuariosPorRolQuery request, CancellationToken cancellationToken)
        {
            return await _rolRepository.ObtenerUsuarioRolAsync(request.IdRol);
        }
    }
}
