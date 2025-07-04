using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Objetivo;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Objetivo
{
    public class EditarObjetivoHandler : IRequestHandler<EditarObjetivoCommand, int>
    {
        private readonly IObjetivoRepository _repository;

        public EditarObjetivoHandler(IObjetivoRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(EditarObjetivoCommand request, CancellationToken cancellationToken)
        {
            var dto = request.DTO;
            return await _repository.EditarObjetivoAsync(dto.IdObjetivo, dto.Nombre, dto.Descripcion);
        }
    }
}
