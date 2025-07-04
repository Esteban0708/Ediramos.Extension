using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.AreTrabajo;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.AreaTrabajo
{
    public class ObtenerAreaTrabajoHandler : IRequestHandler<ObtenerAreaTrabajoQuery, List<ObtenerAreaTrabajoDTo>>
    {
        private readonly IAreaTrabajoRepository _repository;
        public ObtenerAreaTrabajoHandler(IAreaTrabajoRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ObtenerAreaTrabajoDTo>> Handle(ObtenerAreaTrabajoQuery request, CancellationToken cancellationToken)
        {
            var areasTrabajo = await _repository.ObtenerAreasTrabajoAsync();
            return areasTrabajo.Select(o => new ObtenerAreaTrabajoDTo
            {
                IdAreaTrabajo = o.IdAreaTrabajo,
                Nombre = o.Nombre,
                Estado = o.Estado
            }).ToList();
        }
    }
}
