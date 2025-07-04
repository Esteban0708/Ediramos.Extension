using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.InscripcionGrupo;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Aplicacion.Servicios;
using Ediramos.Extension.Dominio.Entidades;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.InscripcionGrupo
{
    public class ActualizarEstadoGrupoHandler : IRequestHandler<ActualizarEstadoGrupoInscriCommand, bool>
    {
        private readonly IInscripcionGrupoRepository _grupoRepository;
        private readonly CorreoService _correoService;
        private readonly IMediator _mediator;

        public ActualizarEstadoGrupoHandler(IInscripcionGrupoRepository grupoRepository, CorreoService correoService, IMediator mediator)
        {
            _grupoRepository = grupoRepository;
            _correoService = correoService;
            _mediator = mediator;
        }

        public async Task<bool> Handle(ActualizarEstadoGrupoInscriCommand request, CancellationToken cancellationToken)
        {
            var entidad = new ActualizarEstadoGrupoIncri
            {
                IdGrupo = request.Datos.IdGrupo,
                Estado = request.Datos.Estado,
                Observacion = request.Datos.Observacion
            };
            var actualizado = await _grupoRepository.ActualizarEstadoGrupoAsync(entidad);
               
            if (!actualizado) return false;

            var (grupos, internos, externos) = await _grupoRepository.ObtenerInscripcionGrupoAsync(true);
            var grupo = grupos.FirstOrDefault(g => g.IdGrupo == entidad.IdGrupo);
           
            var integrantesGrupo = internos.Where(i => i.IdGrupo == entidad.IdGrupo).ToList();

            var documentos = integrantesGrupo.Select(i => i.DocumentoIdentidad).Distinct().ToList();
            var pegeIds = new List<int>();

            foreach (var doc in documentos)
            {
                var pegeId = await _grupoRepository.ObtenerPegeIdPorDocumentoAsync(doc); 
                if (pegeId.HasValue)
                    pegeIds.Add(pegeId.Value);
            }

            var correosBD = await _mediator.Send(new ObtenerCorreosQuery(pegeIds, documentos));
            var correosExternos = externos
                .Where(e => e.IdGrupo == entidad.IdGrupo && !string.IsNullOrWhiteSpace(e.Correo))
                .Select(e => e.Correo)
                .ToList();
           
            var listaCorreos = correosBD.Select(c => c.Correo)
                .Concat(correosExternos)
                .Distinct()
                .ToList();

            if (listaCorreos.Any())
            {
                string asunto = $"📌 Estado actualizado: Grupo {grupo.Titulo}";

                string cuerpo = $@"
                <p>El grupo <strong>{grupo.Titulo}</strong> ha sido <strong>{entidad.Estado.ToUpper()}</strong>.</p>
                {(string.IsNullOrWhiteSpace(entidad.Observacion) ? "" : $"<p><strong>Observación:</strong> {entidad.Observacion}</p>")}
                <p>Por favor, revisa los próximos pasos en el sistema de extensión y proyección social.</p>";

                try
                {
                    Console.WriteLine("correo enviado back");

                    await _correoService.EnviarCorreoGenericoAsync(listaCorreos, asunto, cuerpo);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al enviar correo en ActualizarEstadoGrupoHandler", ex);
                }
            }

            return true;
        }


    }
}
