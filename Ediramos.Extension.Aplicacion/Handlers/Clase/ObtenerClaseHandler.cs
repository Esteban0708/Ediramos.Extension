using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Clase;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Clase
{
    public class ObtenerClaseHandler : IRequestHandler<ObtenerClaseQuery, List<ObtenerClaseDTo>>
    {
        private readonly IClaseRepository _repo;
        public ObtenerClaseHandler(IClaseRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<ObtenerClaseDTo>> Handle(ObtenerClaseQuery request, CancellationToken cancellationToken)
        {
            var clases = await _repo.ObtenerClaseAsync();
            return clases.Select(c => new ObtenerClaseDTo
            {
                IdClase = c.IdClase,
                Nombre = c.Nombre,
                Codigo = c.Codigo,
                Estado = c.Estado,
                fk_grupo = c.fk_grupo
            }).ToList();
        }
    }
}
