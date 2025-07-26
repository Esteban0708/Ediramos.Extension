using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Entidades;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Proyecto
{
    public class ObtenerAnexosProyectoHandler : IRequestHandler<ObtenerAnexosProyectoQuery, ProyectoAnexo>
    {
        private readonly IProyectoAnexoRepository _repo;

        public ObtenerAnexosProyectoHandler(IProyectoAnexoRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProyectoAnexo?> Handle(ObtenerAnexosProyectoQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPorProyectoAsync(request.IdProyecto);
        }
    }
}
