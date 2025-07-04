using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.CicloVida;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.CicloVida
{
    public class CrearCicloVidaHandler : IRequestHandler<CrearCicloVidaCommand, int>
    {
        private readonly ICicloVidaRepository _repo;
        public CrearCicloVidaHandler(ICicloVidaRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(CrearCicloVidaCommand request, CancellationToken cancellationToken)
        {
            return await _repo.CrearCicloVidaAsync(
                request.DTO.Nombre
            );
        }
    }
}
