using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.UnidadMedida;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.UnidadMedida
{
    public class ObtenerUnidadMedidaHandler : IRequestHandler<ObtenerUnidadMedidaQuery, List<ObtenerUnidadMedidaDTo>>
    {
        private readonly IUnidadMedidaRepository _repo;
        public  ObtenerUnidadMedidaHandler(IUnidadMedidaRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<ObtenerUnidadMedidaDTo>> Handle(ObtenerUnidadMedidaQuery request, CancellationToken cancellationToken)
        {
            var unidadMedida = await _repo.ObtenerUnidadMedidaAsync();
            return unidadMedida.Select(u => new ObtenerUnidadMedidaDTo
            {
                IdUnidadMedida = u.IdUnidadMedida,
                Nombre = u.Nombre,
                Descripcion = u.Descripcion,
                Estado = u.Estado
            }).ToList();
        }
    }
}
