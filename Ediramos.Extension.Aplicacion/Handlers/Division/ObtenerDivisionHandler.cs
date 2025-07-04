using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Division;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Division
{
    public class ObtenerDivisionHandler : IRequestHandler<ObtenerDivisionQuery, List<ObtenerDivisionDTO>>
    {
        private readonly IDivisionRepository _repo;
        public ObtenerDivisionHandler(IDivisionRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<ObtenerDivisionDTO>> Handle(ObtenerDivisionQuery request, CancellationToken cancellationToken)
        {
            var division = await _repo.ObtenerDivisionAsync();

            return division.Select(d => new ObtenerDivisionDTO
            {
                IdDivison = d.IdDivision,
                Nombre = d.Nombre,
                Codigo = d.Codigo,
                Estado = d.Estado,
                fk_sesion = d.fk_sesion,

            }).ToList();
        }
    }
}
