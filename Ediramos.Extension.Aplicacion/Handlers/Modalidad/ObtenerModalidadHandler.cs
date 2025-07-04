using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Modalidad;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Modalidad
{
    public class ObtenerModalidadHandler : IRequestHandler<ObtenerModalidadQuery, List<ObtenerModalidadDTo>>
    {
        private readonly IModalidadRepository _repository;

        public ObtenerModalidadHandler(IModalidadRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ObtenerModalidadDTo>> Handle(ObtenerModalidadQuery request, CancellationToken cancellationToken)
        {
            var modalidades = await _repository.ObtenerModalidadesAsync();
            return modalidades.Select(o => new ObtenerModalidadDTo
            {
                IdModalidad = o.IdModalidad,
                Nombre = o.Nombre,
                Estado = o.Estado
            }).ToList();
        }
    }
}
