using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Linea;
using Ediramos.Extension.Aplicacion.DTOs.Permisos;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Entidades;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Permisos
{
    public class ObtenerPermisosHandler : IRequestHandler<ObtenerPermisosQuery, List<ObtenerPermisosDTo>>
    {
        private readonly IPermisosRepository _repository;
        public ObtenerPermisosHandler(IPermisosRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ObtenerPermisosDTo>> Handle(ObtenerPermisosQuery request, CancellationToken cancellationToken)
        {
            var permisos = await _repository.ObtenerPermisosAsync();
            return permisos.Select(p => new ObtenerPermisosDTo
            {
                IdPermiso = p.IdPermiso,
                Nombre = p.Nombre
            }).ToList();
        }
    }
    
}
