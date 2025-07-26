using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.InscripcionGrupo;
using Ediramos.Extension.Aplicacion.DTOs.Usuario;
using Ediramos.Extension.Aplicacion.DTOs.UsuarioExterno;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.InscripcionGrupo
{
    public class ObtenerHistorialGrupoHandler : IRequestHandler<ObtenerHistorialGrupoQuery, List<ObtenerInscripcionGrupoDTo>>
    {
        private readonly IInscripcionGrupoRepository _repo;
        private readonly IMediator _mediator;

        public ObtenerHistorialGrupoHandler(IInscripcionGrupoRepository repo, IMediator mediator)
        {
            _repo = repo;
            _mediator = mediator;
        }

        public async Task<List<ObtenerInscripcionGrupoDTo>> Handle(ObtenerHistorialGrupoQuery request, CancellationToken cancellationToken)
        {
            var historialBase = await _repo.ObtenerHistorialGrupoConIntegrantesAsync(request.Documento);

            var documentosUnicos = historialBase
                .SelectMany(g => g.Internos)
                .Select(i => i.DocumentoIdentidad)
                .Distinct()
                .ToList();

            var infoUsuarios = new List<ObtenerInforUsuarioDTo>();
            const int LOTE = 100;
            for (int i = 0; i < documentosUnicos.Count; i += LOTE)
            {
                var subLista = documentosUnicos.Skip(i).Take(LOTE).ToList();
                var csv = string.Join(",", subLista);
                var parcial = await _mediator.Send(new ObtenerInfoUsuarioQuery(csv));
                infoUsuarios.AddRange(parcial);
            }

            var dicUsuarios = infoUsuarios
     .Where(u => !string.IsNullOrEmpty(u.Documento))
     .GroupBy(u => u.Documento)
     .Select(g => g.First())
     .ToDictionary(u => u.Documento);

            var resultado = historialBase
                .AsParallel()
                .Select(grupo =>
                {
                    var internosCompletos = grupo.Internos
                        .Select(i =>
                        {
                            if (!dicUsuarios.TryGetValue(i.DocumentoIdentidad, out var datos)) return null;
                            return new ObtenerInforUsuarioDTo
                            {
                                Pege_id = datos.Pege_id,
                                Documento = datos.Documento,
                                Nombres = datos.Nombres,
                                Apellidos = datos.Apellidos,
                                Dependencia = datos.Dependencia,
                                Programa = datos.Programa,
                                Eps = datos.Eps,
                                TipoVinculacion = datos.TipoVinculacion,
                                EsLider = i.EsLider ?? false 
                            };
                        })
                        .Where(i => i != null)
                        .ToList();

                    var externosCompletos = grupo.Externos
                        .GroupBy(e => e.DocumentoIdentidad)
                        .Select(g => g.First())
                        .Select(e => new CrearUsuarioExternoDTo
                        {
                            DocumentoIdentidad = long.Parse(e.DocumentoIdentidad),
                            Nombres = (e.NombreCompleto ?? "").Split(" ").FirstOrDefault() ?? "",
                            Apellidos = (e.NombreCompleto ?? "").Split(" ").Skip(1).DefaultIfEmpty("").Aggregate((a, b) => a + " " + b).Trim(),
                            EPS = e.EPS ?? "",
                            Correo = e.Correo
                        }).ToList();

                    return new ObtenerInscripcionGrupoDTo
                    {
                        IdGrupo = grupo.IdGrupo,
                        Titulo = grupo.Titulo,
                        AreaTrabajo = grupo.DescripcionAreaTrabajo,
                        FechaCreacion = grupo.FechaCreacion,
                        EstadoActual = grupo.Estado,
                        Observacion = grupo.Observacion,
                        Internos = internosCompletos,
                        Externos = externosCompletos
                    };
                })
                .ToList();

            return resultado;
        }
    }
}
