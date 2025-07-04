using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Sesion;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Sesion
{
    public class ObtenerSesionHandler : IRequestHandler<ObtenerSesionQuery, List<ObtenerSesionDTo>>
    {
        private readonly ISesionRepository _repo;
        public ObtenerSesionHandler(ISesionRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ObtenerSesionDTo>> Handle(ObtenerSesionQuery request, CancellationToken cancellationToken)
        {
            var sesiones = await _repo.ObtenerSesionesAsync();

            return sesiones.Select(s => new ObtenerSesionDTo
            {
                IdSesion = s.IdSesion,
                Nombre = s.Nombre,
                Codigo = s.Codigo
            }).ToList();
        }
    }
}
