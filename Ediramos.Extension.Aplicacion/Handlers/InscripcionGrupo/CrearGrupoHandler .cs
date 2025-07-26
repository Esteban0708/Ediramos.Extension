using System.Threading;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.InscripcionGrupo;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Aplicacion.Servicios;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.InscripcionGrupo
{
    public class CrearGrupoHandler : IRequestHandler<InscripcionGrupoCommand, int>
    {
        private readonly IInscripcionGrupoRepository _repository;
        private readonly CorreoService _correoService;
        private readonly IMediator _mediator;


        public CrearGrupoHandler(IInscripcionGrupoRepository repository,CorreoService correoService, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
            _correoService = correoService;
        }

        public async Task<int> Handle(InscripcionGrupoCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Grupo;

            var idGrupo = await _repository.CrearGrupoAsync(dto.Titulo, dto.IdAreaTrabajo);

            foreach (var integrante in dto.Integrantes)
            {
                await _repository.AgregarIntegranteAsync(
                    idGrupo,
                    integrante.Pege_id,
                    integrante.Documento,
                    integrante.NombreCompleto,
                    integrante.EsLider,
                    integrante.TipoVinculacion
                );
            }

            foreach (var objetivo in dto.Objetivos)
            {
                await _repository.AgregarObjetivoAsync(idGrupo, objetivo);
            }
           
                var pegeIds = dto.Integrantes.Select(i => i.Pege_id).ToList();
                var documentos = dto.Integrantes.Select(i => i.Documento).ToList();

                var correosBD = await _mediator.Send(new ObtenerCorreosQuery(pegeIds, documentos));

                var listaCorreos = correosBD
                    .Select(c => c.Correo?.Trim())
                    .Where(c => !string.IsNullOrEmpty(c) && CorreoEsValido(c))
                    .Distinct()
                    .ToList();

            if (listaCorreos.Any())
            {
                try
                {
                    var cuerpo = $@"
            <p>Se ha realizado correctamente la inscripción del grupo <strong>{dto.Titulo}</strong>.</p>
            <p>Te notificamos que formas parte de este proceso dentro del sistema de extensión y proyección social.</p>
            <p>Gracias por tu participación.</p>";

                    await _correoService.EnviarCorreoGenericoAsync(listaCorreos, $"Inscripción al grupo: {dto.Titulo}", cuerpo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("⚠️ Error al enviar el correo: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("⚠️ No se enviaron correos porque ninguno de los integrantes tiene correo válido.");
            }


            return idGrupo;
        }
        private bool CorreoEsValido(string correo)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(correo);
                return addr.Address == correo;
            }
            catch
            {
                return false;
            }
        }

    }
}
