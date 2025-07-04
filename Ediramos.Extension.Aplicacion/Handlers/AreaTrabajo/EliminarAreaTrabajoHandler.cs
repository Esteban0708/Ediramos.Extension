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
    public class EliminarAreaTrabajoHandler : IRequestHandler<EliminarAreaTrabajoCommand, int>
    {
        private readonly IAreaTrabajoRepository _repository;
        public EliminarAreaTrabajoHandler(IAreaTrabajoRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(EliminarAreaTrabajoCommand request, CancellationToken cancellationToken)
        {
            return await _repository.EliminarAreaTrabajoAsync(request.IdAreaTrabajo);
        }
    }

}
