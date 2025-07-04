using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Rol;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.RolPermisos
{
    public class CrearRolHandler : IRequestHandler<CrearRolCommand, bool>
    {
        private readonly IRolRepository _repository;

        public CrearRolHandler(IRolRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CrearRolCommand request, CancellationToken cancellationToken)
        {
            var permisos = request.Permisos ?? new List<int>();

            await _repository.CrearRolAsync(request.Nombre, request.ColorHex, permisos);
            return true;
        }

    }
}
