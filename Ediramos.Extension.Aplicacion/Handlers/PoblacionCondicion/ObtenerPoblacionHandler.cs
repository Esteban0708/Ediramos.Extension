using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.PoblacionCondicion;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.PoblacionCondicion
{
    public class ObtenerPoblacionHandler : IRequestHandler<ObtenerPoblacionQuery, List<ObtenerPoblacionDTo>>
    {
        private readonly IPoblacionRepository _repository;
        public ObtenerPoblacionHandler(IPoblacionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ObtenerPoblacionDTo>> Handle(ObtenerPoblacionQuery request, CancellationToken cancellationToken)
        {
            var poblaciones = await _repository.ObtenerPoblacionAsync();
            return poblaciones.Select(o => new ObtenerPoblacionDTo
            {
                IdPoblacion = o.IdPoblacion,
                Nombre = o.Nombre,
                Estado = o.Estado
            }).ToList();
        }
    }
}
