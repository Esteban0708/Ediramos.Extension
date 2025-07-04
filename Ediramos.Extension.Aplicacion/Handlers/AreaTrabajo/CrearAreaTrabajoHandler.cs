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
    public class CrearAreaTrabajoHandler : IRequestHandler<CrearAreaTrabajoCommand, int>
    {
        private readonly IAreaTrabajoRepository _repo;
        public CrearAreaTrabajoHandler(IAreaTrabajoRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(CrearAreaTrabajoCommand request, CancellationToken cancellationToken)
        {
            return await _repo.CrearAreaTrabajoAsync(
                request.DTO.Nombre
            );
        }
    }

}
