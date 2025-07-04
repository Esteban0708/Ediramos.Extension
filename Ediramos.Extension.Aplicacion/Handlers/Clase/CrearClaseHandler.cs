using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Clase;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Clase
{
    public class CrearClaseHandler : IRequestHandler<CrearClaseCommand, int>
    {
        private readonly IClaseRepository _repo;
        public CrearClaseHandler(IClaseRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(CrearClaseCommand request, CancellationToken cancellationToken)
        {
            return await _repo.CrearClaseAsync(
                request.DTO.Nombre,
                request.DTO.Codigo,
                request.DTO.fk_grupo
            );
        }
    }

}
