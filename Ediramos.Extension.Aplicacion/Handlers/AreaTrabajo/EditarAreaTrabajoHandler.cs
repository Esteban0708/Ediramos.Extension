using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.AreaTrabajo;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.AreaTrabajo
{
    public class EditarAreaTrabajoHandler : IRequestHandler<EditarAreaTrabajoCommand, int>
    {
        private readonly IAreaTrabajoRepository _repository;
        public EditarAreaTrabajoHandler(IAreaTrabajoRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(EditarAreaTrabajoCommand request, CancellationToken cancellationToken)
        {
            var dto = request.DTO;
            return await _repository.EditarAreaTrabajoAsync(
                dto.IdAreaTrabajo,
                dto.Nombre
            );
        }
    }
}
