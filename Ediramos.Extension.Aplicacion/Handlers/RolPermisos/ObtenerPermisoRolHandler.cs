using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Permisos;
using Ediramos.Extension.Aplicacion.DTOs.RolPermisos;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.RolPermisos
{
    public class ObtenerPermisoRolHandler : IRequestHandler<ObtenerPermisoRolQuery, List<ObtenerPermisosRolDTo>>
    {
        private readonly IRolRepository _repository;

        public ObtenerPermisoRolHandler(IRolRepository repository) { 
        
            _repository = repository;
        }

        public async Task<List<ObtenerPermisosRolDTo>> Handle(ObtenerPermisoRolQuery request, CancellationToken cancellationToken)
        {
            var permisoRol = await _repository.ObtenerPermisoRolAsync(); 
            var rolesAgrupados = permisoRol
                .GroupBy(p => p.IdRol)
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
