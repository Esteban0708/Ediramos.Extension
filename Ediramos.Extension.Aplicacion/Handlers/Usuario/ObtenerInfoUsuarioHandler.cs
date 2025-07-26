using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Usuario;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Usuario
{
    public class ObtenerInfoUsuarioHandler : IRequestHandler<ObtenerInfoUsuarioQuery, List<ObtenerInforUsuarioDTo>>
    {
        private readonly IUsuarioRepository _repository;
        public ObtenerInfoUsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ObtenerInforUsuarioDTo>> Handle(ObtenerInfoUsuarioQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _repository.ObtenerInfoUsuarioAsync(request.Documento);
            return usuarios.Select(u => new ObtenerInforUsuarioDTo
            {
                Pege_id = u.Pege_id,
                Documento = u.Documento,
                Nombres = u.Nombres,
                Apellidos = u.Apellidos,
                Dependencia = u.Dependencia,
                Programa = u.Programa,
                Eps = u.Eps,
                TipoVinculacion = u.Estatus
            }).ToList();
        }
    }
}
