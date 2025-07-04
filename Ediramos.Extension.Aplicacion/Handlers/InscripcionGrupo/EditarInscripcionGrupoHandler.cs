using Ediramos.Extension.Aplicacion.Commands.InscripcionGrupo;
using Ediramos.Extension.Aplicacion.DTOs.InscripcionGrupo;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Aplicacion.Servicios;
using Ediramos.Extension.Dominio.Entidades;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.Handlers.InscripcionGrupo
{
    public class EditarInscripcionGrupoHandler : IRequestHandler<EditarInscripcionGrupoCommand, bool>
    {
        private readonly IInscripcionGrupoRepository _repository;
        private readonly CorreoService _correoService;
        private readonly IMediator _mediator;

        public EditarInscripcionGrupoHandler(IInscripcionGrupoRepository repository, CorreoService correoService, IMediator mediator)
        {
            _repository = repository;
            _correoService = correoService;
            _mediator = mediator;
        }

        public async Task<bool> Handle(EditarInscripcionGrupoCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Grupo;

            var jsonIntegrantes = JsonSerializer.Serialize(dto.Integrantes);

            var objetivosConvertidos = dto.Objetivos.Select((descripcion, index) => new ObjetivoGrupo
            {
                IdObjetivo = 0, 
                Descripcion = descripcion
            }).ToList();


            var jsonObjetivos = JsonSerializer.Serialize(objetivosConvertidos);

            await _repository.EditarInscripcionGrupoAsync(
                request.IdGrupo,
                dto.Titulo,
                dto.IdAreaTrabajo,
                jsonIntegrantes,
                jsonObjetivos,
                dto.Estado
            );

            var pegeIds = dto.Integrantes.Select(i => i.Pege_id).ToList();
            var documentos = dto.Integrantes.Select(i => i.Documento).ToList();
            var correosBD = await _mediator.Send(new ObtenerCorreosQuery(pegeIds, documentos));
            var listaCorreos = correosBD.Select(c => c.Correo).Distinct().ToList();

            if (listaCorreos.Any())
            {
                var cuerpo = $@"
        <p>Se ha actualizado correctamente la inscripción del grupo <strong>{dto.Titulo}</strong>.</p>
        <p>Te notificamos que formas parte de este proceso dentro del sistema de extensión y proyección social.</p>
        <p>Gracias por tu participación.</p>";

                await _correoService.EnviarCorreoGenericoAsync(listaCorreos, $"Actualización del grupo: {dto.Titulo}", cuerpo);
            }

            return true;
        }

    }


}
