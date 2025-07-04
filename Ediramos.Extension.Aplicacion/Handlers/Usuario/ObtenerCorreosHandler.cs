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
    public class ObtenerCorreosHandler : IRequestHandler<ObtenerCorreosQuery, List<CorreoUsuarioDTo>>
    {
        private readonly IUsuarioRepository _repo;

        public ObtenerCorreosHandler(IUsuarioRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<CorreoUsuarioDTo>> Handle(ObtenerCorreosQuery request, CancellationToken cancellationToken)
        {
            var entidades = await _repo.ObtenerCorreosPorPegeIdsYDocumentosAsync(request.PegeIds, request.Documentos);

            return entidades.Select(e => new CorreoUsuarioDTo
            {
                Pege_id = e.Pege_id,
                Correo = e.Correo
            }).ToList();
        }
    }
}
