using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Division;
using Ediramos.Extension.Aplicacion.DTOs.Objetivo;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Objetivo
{
    public class ObtenerObjetivosHandler : IRequestHandler<ObtenerObjetivosQuery, List<ObtenerObjetivoDTO>>
    {
        private readonly IObjetivoRepository _repository;

        public ObtenerObjetivosHandler(IObjetivoRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ObtenerObjetivoDTO>> Handle(ObtenerObjetivosQuery request, CancellationToken cancellationToken)
        {
            var objetivos = await _repository.ObtenerObjetivosAsync();

            return objetivos.Select(o => new ObtenerObjetivoDTO
            {
                IdObjetivo = o.IdObjetivo,
                Nombre = o.Nombre,
                Descripcion = o.Descripcion,
                Estado = o.Estado
            }).ToList();
        }
    }
}
