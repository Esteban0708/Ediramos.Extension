using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.UsuarioExterno;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.UsuarioExterno
{
    public class ObtenerUsuarioExternoHandler : IRequestHandler<ObtenerUsuarioExternoQuery, List<ObtenerUsuarioExternoDTo>>
    {
        private readonly IUsuarioExternoRepository _repository;

        public ObtenerUsuarioExternoHandler(IUsuarioExternoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ObtenerUsuarioExternoDTo>> Handle(ObtenerUsuarioExternoQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _repository.ObtenerUsuarioExternoAsync(request.DocumentoParcial);

            return usuarios.Select(u => new ObtenerUsuarioExternoDTo
            {
                DocumentoIdentidad = u.DocumentoIdentidad,
                Nombres = u.Nombres,
                Apellidos = u.Apellidos,
                EPS = u.EPS
            }).ToList();
        }
    }

}
