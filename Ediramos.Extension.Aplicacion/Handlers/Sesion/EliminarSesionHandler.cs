using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Sesion;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Sesion
{
    public class EliminarSesionHandler : IRequestHandler<EliminarSesionCommand, int>
    {
        private readonly ISesionRepository _repo;
        public EliminarSesionHandler(ISesionRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(EliminarSesionCommand request, CancellationToken cancellationToken)
        {
            await _repo.EliminarSesionAsync(request.IdSesion);
            return 1; 
        }
    }
}
