using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Producto;
using Ediramos.Extension.Aplicacion.Commands.Proyecto;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Aplicacion.Servicios;
using Ediramos.Extension.Dominio.Entidades;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Proyecto
{
    public class CrearProyectoHandler : IRequestHandler<CrearProyectoCommand, int>
    {
        private readonly IProyectoRepository _repo;
        private readonly CorreoService _correoService;
        private readonly IMediator _mediator;
        private readonly IInscripcionGrupoRepository _grupoRepository;
        public CrearProyectoHandler(IProyectoRepository repo, CorreoService correoService, IMediator mediator, IInscripcionGrupoRepository grupoRepository)
        {
            _repo = repo;
            _correoService = correoService;
            _mediator = mediator;
            _grupoRepository = grupoRepository;
        }

        public async Task<int> Handle(CrearProyectoCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Proyecto;

            var proyecto = new ProyectoCompleto
            {
                NombreProyecto = dto.NombreProyecto,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                Duracion = dto.Duracion,
                ObjetivoGeneral = dto.ObjetivoGeneral,
                PlanteamientoProblema = dto.PlanteamientoProblema,
                Metodologia = dto.Metodologia,
                Justificacion = dto.Justificacion,
                ComponenteInnovador = dto.ComponenteInnovador,
                PoblacionDirigida = dto.PoblacionDirigida,
                ResultadoAcciones = dto.ResultadoAcciones,
                Estado = true,
                IdConvocatoria = dto.IdConvocatoria
            };

            int idProyecto = await _repo.CrearProyectoAsync(proyecto);

            await _repo.AsignarGrupoProyectoAsync(idProyecto, dto.IdGrupo);
            await _repo.InsertarParticipantesInternosAsync(dto.IdGrupo, idProyecto);
            await _repo.InsertarParticipantesExternosAsync(dto.IdGrupo, idProyecto);
            await _repo.InsertarCoberturaAsync(idProyecto, "area", dto.AreasTrabajo);
            await _repo.InsertarCoberturaAsync(idProyecto, "ciclo", dto.CiclosVida);
            await _repo.InsertarCoberturaAsync(idProyecto, "condicion", dto.CondicionesPoblacion);
            await _repo.InsertarCoberturaAsync(idProyecto, "grupo", dto.GruposPoblacionales);

            await _repo.InsertarCronogramaAsync(idProyecto, dto.ObjetivosEspecificos.Select(o => new ObjetivoEspecifico
            {
                Descripcion = o.Descripcion,
                Metas = o.Metas.Select(m => new Meta
                {
                    Descripcion = m.Descripcion,
                    Actividades = m.Actividades.Select(a => new Actividad
                    {
                        Descripcion = a.Descripcion,
                        Periodos = a.Periodos
                    }).ToList()
                }).ToList()
            }).ToList());

            float total = dto.Productos.Sum(p => p.Cantidad * p.ValorUnitario);
            int idPresupuesto = await _repo.CrearPresupuestoAsync(idProyecto, total);
            await _repo.InsertarProductosAsync(idPresupuesto, dto.Productos.Select(p => new ProductoPresupuesto
            {
                IdProducto = p.IdProducto,
                Cantidad = p.Cantidad,
                IdUnidadMedida = p.IdUnidadMedida,
                ValorUnitario = p.ValorUnitario
            }).ToList());

            await _repo.InsertarFuentesAsync(idPresupuesto, dto.Fuentes.Select(f => new FuenteFinanciacion
            {
                Entidad = f.Entidad,
                Valor = f.Valor,
                Estado = true
            }).ToList());

            var pegeIds = new List<int>();
            foreach (var doc in dto.DocumentosInternos)
            {
                var id = await _grupoRepository.ObtenerPegeIdPorDocumentoAsync(doc);
                if (id.HasValue)
                    pegeIds.Add(id.Value);
            }

            var documentos = dto.DocumentosExternos.ToList();

            var correosBD = await _mediator.Send(new ObtenerCorreosQuery(pegeIds, documentos));
            var listaCorreos = correosBD.Select(c => c.Correo).Distinct().ToList();

            if (listaCorreos.Any())
            {
                var cuerpo = $@"
        <p>Te informamos que el grupo <strong>{dto.NombreGrupo}</strong> ha inscrito correctamente el proyecto titulado <strong>{dto.NombreProyecto}</strong>.</p>
        <p>El proceso continuará vía correo electrónico según el cronograma establecido.</p>
        <p>Gracias por hacer parte de la proyección social.</p>";

                await _correoService.EnviarCorreoGenericoAsync(listaCorreos, $"Inscripción de proyecto: {dto.NombreProyecto}", cuerpo);
            }

            return idProyecto;
        }
    }
}
