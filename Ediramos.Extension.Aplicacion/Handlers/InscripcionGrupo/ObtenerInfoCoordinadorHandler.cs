using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.InscripcionGrupo;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.InscripcionGrupo
{
    public class ObtenerInfoCoordinadorHandler : IRequestHandler<ObtenerInfoCoordinadorQuery, List<ObtenerInfoCoordinaDTo>>
    {
        private readonly IInforCoordinadorRepository _repo;
        public ObtenerInfoCoordinadorHandler(IInforCoordinadorRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<ObtenerInfoCoordinaDTo>> Handle(ObtenerInfoCoordinadorQuery request, CancellationToken cancellationToken)
        {
            var info = await _repo.ObtenerInformacionAsync(request.Documento); 

            return info.Select(i => new ObtenerInfoCoordinaDTo
            {
                Pege_id = i.Pege_id,
                Documento = i.Documento,
                Peng_emailinstitucional = i.Peng_emailinstitucional,
                Pege_Telefono = i.Pege_Telefono
            }).ToList();
        }

    }
}
