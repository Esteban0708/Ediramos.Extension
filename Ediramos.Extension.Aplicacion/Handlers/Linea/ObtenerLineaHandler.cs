using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Linea;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Linea
{
    public class ObtenerLineaHandler : IRequestHandler<ObtenerLineasQuery, List<ObtenerLineaDTo>>
    {
        private readonly ILineaRepository _repository;

        public ObtenerLineaHandler(ILineaRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ObtenerLineaDTo>> Handle(ObtenerLineasQuery request, CancellationToken cancellationToken)
        {
            var Linea = await _repository.ObtenerLineasAsync();
            return Linea.Select(o => new ObtenerLineaDTo
            {
                IdLineaProfundizacion = o.IdLinea,
                Nombre = o.Nombre,
                Estado = o.Estado
            }).ToList();
        }
    }
}
