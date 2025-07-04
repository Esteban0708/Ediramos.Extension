using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Modalidad;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Modalidad
{
    public class CrearModalidadHandler : IRequestHandler<CrearModalidadCommand, int>
    {
        private readonly IModalidadRepository _repo;
        public CrearModalidadHandler(IModalidadRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(CrearModalidadCommand request, CancellationToken cancellationToken)
        {
            return await _repo.CrearModalidadAsync(
                request.DTO.Nombre
            );
        }
    }
}
