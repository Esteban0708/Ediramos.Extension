using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Grupo;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Grupo
{
    public  class ObtenerGrupoHandler : IRequestHandler<ObtenerGrupoQuery, List<ObtenerGrupoDTO>>
    {
        private readonly IGrupoRepository _repo;
        public ObtenerGrupoHandler(IGrupoRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<ObtenerGrupoDTO>> Handle(ObtenerGrupoQuery request, CancellationToken cancellationToken)
        {
            var grupo = await _repo.ObtenerGrupoAsync();
            return grupo.Select(g => new ObtenerGrupoDTO
            {
                IdGrupo = g.IdGrupo,
                Nombre = g.Nombre,
                Codigo = g.Codigo,
                Estado = g.Estado,
                fk_division = g.fk_division,
            }).ToList();
        }
    }
}
