using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Convocatoria;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Convocatoria
{
    public class AsignarItemsConvocatoriaHandler : IRequestHandler<AsignarItemsConvocatoriaCommand, bool>
    {
        private readonly IItemsRepository _repository;

        public AsignarItemsConvocatoriaHandler(IItemsRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(AsignarItemsConvocatoriaCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.DTO.Items)
            {
                await _repository.AsignarItemConvocatoriaAsync(
                    item.Titulo,
                    item.Pregunta,
                    item.EsEstandar,
                    item.Estado,
                    request.DTO.IdConvocatoria,
                    item.PuntajeMax,
                    item.PuntajeMin
                );
            }

            return true;
        }
    }
}
