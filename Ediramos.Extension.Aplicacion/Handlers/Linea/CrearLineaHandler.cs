using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Linea;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Linea
{
    public class CrearLineaHandler : IRequestHandler<CrearLineaCommand, int>
    {
        private readonly ILineaRepository  _repo;

        public CrearLineaHandler(ILineaRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(CrearLineaCommand request, CancellationToken cancellationToken)
        {
            return await _repo.CrearLineaAsync(
                request.DTO.Nombre
            );
        }
    }
}
