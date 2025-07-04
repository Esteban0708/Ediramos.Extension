using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.PoblacionCondicion;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.PoblacionCondicion
{
    public class EditarPoblacionHandler : IRequestHandler<EditarPoblacionCommand, int>
    {
        private readonly IPoblacionRepository _repository;
        public EditarPoblacionHandler(IPoblacionRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(EditarPoblacionCommand request, CancellationToken cancellationToken)
        {
            return await _repository.EditarPoblacionAsync(
                request.DTO.IdPoblacion,
                request.DTO.Nombre);
        }
    }
}
