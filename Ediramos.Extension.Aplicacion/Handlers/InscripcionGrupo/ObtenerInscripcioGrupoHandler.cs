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
    public class ObtenerInscripcioGrupoHandler : IRequestHandler<ObtenerInscripcionGrupoQuery, List<ObtenerInscripcionGrupoDTo>>
    {
        private readonly IInscripcionGrupoRepository _repo;
        private readonly IMediator _mediator;
        public ObtenerInscripcioGrupoHandler(IInscripcionGrupoRepository repo, IMediator mediator)
        {
            _repo = repo;
            _mediator = mediator;
        }
        public async Task<List<ObtenerInscripcionGrupoDTo>> Handle(ObtenerInscripcionGrupoQuery request, CancellationToken cancellationToken)
        {
            var (gruposBase, internosBase, externosBase) = await _repo.ObtenerInscripcionGrupoAsync(false);

            var documentosUnicos = internosBase
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
                .ToDictionary(u => u.Documento);

            var resultadoParalelo = gruposBase
                .AsParallel()
                .Select(grupo =>
                {
                    var internos = internosBase
                        .Where(i => i.IdGrupo == grupo.IdGrupo)
                        .GroupBy(i => i.DocumentoIdentidad)
                        .Select(g => g.First())
                        .Select(i => new ObtenerInforUsuarioDTo
                        {
                            Documento = i.DocumentoIdentidad,
                            EsLider = i.EsLider ?? false
                        }).ToList();

                    var externos = externosBase
                        .Where(e => e.IdGrupo == grupo.IdGrupo)
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

                    var internosCompletos = internos
                        .Select(i =>
                        {
                            if (!dicUsuarios.TryGetValue(i.Documento, out var datos)) return null;
                            return new ObtenerInforUsuarioDTo
                            {
                                Pege_id = datos.Pege_id,
                                Documento = datos.Documento,
                                Nombres = datos.Nombres,
                                Apellidos = datos.Apellidos,
                                Dependencia = datos.Dependencia,
                                Programa = datos.Programa,
                                Eps = datos.Eps,
                                Estatus = datos.Estatus,
                                EsLider = i.EsLider
                            };
                        })
                        .Where(i => i != null)
                        .ToList();

                    return new ObtenerInscripcionGrupoDTo
                    {
                        IdGrupo = grupo.IdGrupo,
                        Titulo = grupo.Titulo,
                        AreaTrabajo = grupo.AreaTrabajo,
                        FechaCreacion = grupo.FechaCreacion,
                        EstadoActual = grupo.EstadoActual,
                        Internos = internosCompletos,
                        Externos = externos
                    };
                })
                .ToList();

            return resultadoParalelo;
        }

    }
}
