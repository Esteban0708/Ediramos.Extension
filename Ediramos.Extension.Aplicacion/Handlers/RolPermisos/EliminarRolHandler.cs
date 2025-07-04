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
    public class EliminarRolHandler : IRequestHandler<EliminarRolCommand, int>
    {
        private readonly IRolRepository _repository;

        public EliminarRolHandler(IRolRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(EliminarRolCommand request, CancellationToken cancellationToken)
        {
            return await _repository.EliminarRolAsync(request.IdRol);
        }
    }
}
