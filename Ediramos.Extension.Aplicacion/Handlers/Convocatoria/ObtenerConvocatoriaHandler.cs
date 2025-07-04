using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Convocatoria;
using Ediramos.Extension.Aplicacion.DTOs.Linea;
using Ediramos.Extension.Aplicacion.DTOs.Objetivo;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Convocatoria
{
    public class ObtenerConvocatoriaHandler : IRequestHandler<ObtenerConvocatoriaQuery, List<ObtenerConvocatoriaDTo>>
    {
        public readonly IConvocatoriaRepository _repository;
        public ObtenerConvocatoriaHandler(IConvocatoriaRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ObtenerConvocatoriaDTo>> Handle(ObtenerConvocatoriaQuery request, CancellationToken cancellationToken)
        {
            var convocatorias = await _repository.ObtenerConvocatoriasBasicasAsync();

            var resultado = convocatorias.Select(c => new ObtenerConvocatoriaDTo
            {
                IdConvocatoria = c.IdConvocatoria,
                Titulo = c.Titulo,
                Descripcion = c.Descripcion,
                Resolucion = c.Resolucion,
                NResolucion = c.NResolucion,
                FechaInicio = c.FechaInicio,
                FechaFin = c.FechaFin,
                Duracion = c.Duracion,
                Estado = c.Estado,
                IdModalidad = c.IdModalidad,
                ModalidadNombre = c.Modalidad,

                Objetivos = c.Objetivos.Select(o => new ObjetivoDto
                {
                    IdObjetivo = o.IdObjetivo,
                    Nombre = o.Nombre
                }).ToList(),

                Lineas = c.Lineas.Select(l => new ObtenerLineaDTo
                {
                    IdLineaProfundizacion = l.IdLinea,
                    Nombre = l.Nombre
                }).ToList(),

                Items = c.Items.Select(i => new obtenerItemDto
                {
                    IdItem = i.IdItem,
                    Titulo = i.Titulo,
                    Pregunta = i.Pregunta,
                    PuntajeMax = i.PuntajeMax,
                    PuntajeMin = i.PuntajeMin
                }).ToList()

            }).ToList();

            return resultado;
        }



    }
}
