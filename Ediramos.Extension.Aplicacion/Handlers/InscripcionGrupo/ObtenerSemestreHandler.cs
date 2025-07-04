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
    public class ObtenerSemestreHandler : IRequestHandler<ObtenerSemestreQuery, List<ObtenerSemestreDTo>>
    { 
        private readonly IInforCoordinadorRepository _repo;
        public ObtenerSemestreHandler(IInforCoordinadorRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<ObtenerSemestreDTo>> Handle(ObtenerSemestreQuery request, CancellationToken cancellationToken)
        {
            var info = await _repo.ObtenerSemestreAsync(request.Documento);
            return info.Select(i => new ObtenerSemestreDTo
            {
                Pege_id = i.Pege_id,
                Documento = i.Documento,
                Estp_semestreactual = i.Estp_semestreactual
            }).ToList();
   
        }
    }
}
