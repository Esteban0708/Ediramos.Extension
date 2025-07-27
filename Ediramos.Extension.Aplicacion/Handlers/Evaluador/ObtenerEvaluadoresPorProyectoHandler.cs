using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Evaluador;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Evaluador
{
    public class ObtenerEvaluadoresPorProyectoHandler : IRequestHandler<ObtenerEvaluadoresPorProyectoQuery, List<ObtenerEvaluadorDTo>>
    {
        private readonly IEvaluadorRespository _repository;

        public ObtenerEvaluadoresPorProyectoHandler(IEvaluadorRespository repository)
        {
            _repository = repository;
        }

        public async Task<List<ObtenerEvaluadorDTo>> Handle(ObtenerEvaluadoresPorProyectoQuery request, CancellationToken cancellationToken)
        {
            var evaluadores = await _repository.ObtenerEvaluadoresPorProyectoAsync(request.IdProyecto);
            return evaluadores.Select(e => new ObtenerEvaluadorDTo
            {
                PegeId = e.PegeId,
                NombreCompleto = e.NombreCompleto,
                Documento = e.Documento,
                FechaAsignacion = e.FechaAsignacion,
                FechaInicio = e.FechaInicio,
                FechaLimite = e.FechaLimite
            }).ToList();
        }
    }

}
