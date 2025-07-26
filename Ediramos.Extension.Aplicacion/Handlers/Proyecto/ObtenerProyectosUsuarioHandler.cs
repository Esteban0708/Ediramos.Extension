using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Proyecto;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Entidades;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Proyecto
{
    public class ObtenerProyectosUsuarioHandler : IRequestHandler<ObtenerProyectosUsuarioQuery, DetalleProyectosUsuario>
    {
        private readonly IProyectoRepository _repositorio;

        public ObtenerProyectosUsuarioHandler(IProyectoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<DetalleProyectosUsuario> Handle(ObtenerProyectosUsuarioQuery request, CancellationToken cancellationToken)
        {
            return await _repositorio.ObtenerProyectosUsuarioAsync(request.DocumentoIdentidad);
        }
    }
}
