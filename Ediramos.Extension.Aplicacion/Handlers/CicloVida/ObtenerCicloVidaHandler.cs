using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.CicloVida;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.CicloVida
{
    public class ObtenerCicloVidaHandler : IRequestHandler<ObtenerCicloVidaQuery, List<ObtenerCicloVidaDTo>>
    {
        private readonly ICicloVidaRepository _repo;
        public ObtenerCicloVidaHandler(ICicloVidaRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<ObtenerCicloVidaDTo>> Handle(ObtenerCicloVidaQuery request, CancellationToken cancellationToken)
        {
            var ciclosVida = await _repo.ObtenerCicloVidaAsync();
            return ciclosVida.Select(o => new ObtenerCicloVidaDTo
            {
                IdCicloVida = o.IdCicloVida,
                Nombre = o.Nombre,
                Estado = o.Estado
            }).ToList();
        }

    }
}
