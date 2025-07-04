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
    public class CrearSesionHandler : IRequestHandler<CrearSesionCommand, int>
    {
        private readonly ISesionRepository _repo;
        public CrearSesionHandler(ISesionRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(CrearSesionCommand request, CancellationToken cancellationToken)
        {
            return await _repo.CrearSesionAsync(
                request.DTO.Nombre,
                request.DTO.Codigo
            );
        }
    }
}
