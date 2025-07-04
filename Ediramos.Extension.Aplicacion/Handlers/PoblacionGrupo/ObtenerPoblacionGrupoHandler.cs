using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.PoblacionGrupo;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.PoblacionGrupo
{
    public class ObtenerPoblacionGrupoHandler : IRequestHandler<ObtenerPoblacionGrupoQuery, List<ObtenerPoblacionGrupoDTo>>
    {
        private readonly IPoblacionGrupoRepository _repository;
        public ObtenerPoblacionGrupoHandler(IPoblacionGrupoRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ObtenerPoblacionGrupoDTo>> Handle(ObtenerPoblacionGrupoQuery request, CancellationToken cancellationToken)
        {
            var poblaciones = await _repository.ObtenerPoblacionesGruposAsync();
            return poblaciones.Select(o => new ObtenerPoblacionGrupoDTo
            {
                IdGrupo = o.IdGrupo,
                Nombre = o.Nombre,
                Estado = o.Estado
            }).ToList();
        }
    }
}
