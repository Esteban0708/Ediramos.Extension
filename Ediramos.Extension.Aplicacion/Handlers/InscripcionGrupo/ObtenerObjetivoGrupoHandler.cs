using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.InscripcionGrupo;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.InscripcionGrupo
{
    public class ObtenerObjetivoGrupoHandler : IRequestHandler<ObtenerObjetivoGrupoQuery, List<ObtenerObjetivoGrupoDTo>>
    {
        private readonly IInscripcionGrupoRepository _repo;
        public ObtenerObjetivoGrupoHandler(IInscripcionGrupoRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<ObtenerObjetivoGrupoDTo>> Handle(ObtenerObjetivoGrupoQuery request, CancellationToken cancellationToken)
        {
            var objetivos = await _repo.ObtenerObjetivosGrupoAsync(int.Parse(request.IdGrupo));
            return objetivos.Select(o => new ObtenerObjetivoGrupoDTo
            {
                IdObjetivo = o.IdObjetivo,
                Descripcion = o.Descripcion,
                Estado = o.Estado
            }).ToList();
        }
    }
}
