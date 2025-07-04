using Ediramos.Extension.Aplicacion.DTOs.RolPermisos;
using Ediramos.Extension.Aplicacion.DTOs.Permisos;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.RolPermisos
{
    public class ObtenerRolesUsuarioHandler : IRequestHandler<ObtenerRolesDeUsuarioQuery, IEnumerable<ObtenerPermisosRolDTo>>
    {
        private readonly IUsuarioRepository _userepository;

        public ObtenerRolesUsuarioHandler(IUsuarioRepository userepository)
        {
            _userepository = userepository;
        }
        public async Task<IEnumerable<ObtenerPermisosRolDTo>> Handle(ObtenerRolesDeUsuarioQuery request, CancellationToken cancellationToken)
        {
            var roles = await _userepository.ObtenerRolesDeUsuarioAsync(request.PegeId);

            var rolesAgrupados = roles
                .GroupBy(r => r.IdRol)
                .Select(g => new ObtenerPermisosRolDTo
                {
                    IdRol = g.Key,
                    NombreRol = g.First().NombreRol,
                    ColorHex = g.First().ColorHex,
                    Permisos = g.Select(p => new ObtenerPermisosDTo
                    {
                        IdPermiso = p.IdPermiso,
                        Nombre = p.NombrePermiso
                    }).ToList()
                }).ToList();

            return rolesAgrupados;
        }
    }
}

