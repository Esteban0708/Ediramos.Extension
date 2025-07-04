using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Convocatoria;
using Ediramos.Extension.Dominio.Entidades;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Convocatoria
{
    public class CrearConvocatoriaHandler :IRequestHandler<CrearConvocatoriaCommand, int>
    {
        private readonly IConvocatoriaRepository _repository;

        public CrearConvocatoriaHandler(IConvocatoriaRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(CrearConvocatoriaCommand request, CancellationToken cancellationToken)
        {
            var objetivos = (request.DTO.Objetivos != null && request.DTO.Objetivos.Any())
                ? string.Join(",", request.DTO.Objetivos)
                : null;

            var lineas = (request.DTO.Lineas != null && request.DTO.Lineas.Any())
                ? string.Join(",", request.DTO.Lineas)
                : null;
            Console.WriteLine($"📌 Modalidad recibida: {request.DTO.Modalidad}");

            var idConvocatoria = await _repository.CrearConvocatoriaAsync(
                request.DTO.Titulo,
                request.DTO.Descripcion,
                request.DTO.Resolucion,
                request.DTO.NResolucion,
                request.DTO.Modalidad,
                request.DTO.FechaInicio,
                request.DTO.FechaFin,
                request.DTO.Duracion,
                objetivos,
                lineas
            );

            return idConvocatoria;
        }




    }
}
