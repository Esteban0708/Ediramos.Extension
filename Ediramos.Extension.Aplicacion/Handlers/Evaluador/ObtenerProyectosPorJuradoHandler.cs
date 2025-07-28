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
    public class ObtenerProyectosPorJuradoHandler : IRequestHandler<ObtenerProyectosPorJuradoQuery, List<ProyectoJuradoCompletoDTo>>
    {
        private readonly IEvaluadorRespository _repository;

        public ObtenerProyectosPorJuradoHandler(IEvaluadorRespository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProyectoJuradoCompletoDTo>> Handle(ObtenerProyectosPorJuradoQuery request, CancellationToken cancellationToken)
        {
            var entidades = await _repository.ObtenerProyectosPorJuradoAsync(request.Documento);

            var resultado = entidades.Select(e => new ProyectoJuradoCompletoDTo
            {
                Proyecto = new ProyectoJuradoDTo
                {
                    IdProyecto = e.Proyecto.IdProyecto,
                    NombreProyecto = e.Proyecto.NombreProyecto,
                    FechaPresentacion = e.Proyecto.FechaPresentacion,
                    FechaInicio = e.Proyecto.FechaInicio,
                    FechaFin = e.Proyecto.FechaFin,
                    Duracion = e.Proyecto.Duracion,
                    ObjetivoGeneral = e.Proyecto.ObjetivoGeneral,
                    PlanteamientoProblema = e.Proyecto.PlanteamientoProblema,
                    Metodologia = e.Proyecto.Metodologia,
                    Justificacion = e.Proyecto.Justificacion,
                    ComponenteInnovador = e.Proyecto.ComponenteInnovador,
                    PoblacionDirigida = e.Proyecto.PoblacionDirigida,
                    ResultadoAcciones3_1 = e.Proyecto.ResultadoAcciones3_1,
                    Estado = e.Proyecto.Estado,
                    FK_IdConvocatoria = e.Proyecto.FK_IdConvocatoria,
                    TituloConvocatoria = e.Proyecto.TituloConvocatoria,
                    Descripcion = e.Proyecto.Descripcion,
                    EstadoConvocatoria = e.Proyecto.EstadoConvocatoria,
                    EstadoProyecto = e.Proyecto.EstadoProyecto,
                    ObservacionProyecto = e.Proyecto.ObservacionProyecto,
                    FechaEstadoProyecto = e.Proyecto.FechaEstadoProyecto
                },
                ParticipantesInternos = e.ParticipantesInternos.Select(i => new ParticipanteInternoDTo
                {
                    PegeId = i.PegeId,
                    NombreCompleto = i.NombreCompleto,
                    DocumentoIdentidad = i.DocumentoIdentidad,
                    TipoVinculacion = i.TipoVinculacion,
                    IdGrupo = i.IdGrupo,
                    TituloGrupo = i.TituloGrupo,
                    EsLider = i.EsLider,
                    IdProyecto = i.IdProyecto
                }).ToList(),
                ParticipantesExternos = e.ParticipantesExternos.Select(ex => new ParticipanteExternoDTo
                {
                    IdUsuarioExterno = ex.IdUsuarioExterno,
                    Nombres = ex.Nombres,
                    Apellidos = ex.Apellidos,
                    DocumentoIdentidad = ex.DocumentoIdentidad,
                    Correo = ex.Correo,
                    EPS = ex.EPS,
                    FK_IdProyecto = ex.IdProyecto
                }).ToList()
            }).ToList();

            return resultado;
        }
    }


}
