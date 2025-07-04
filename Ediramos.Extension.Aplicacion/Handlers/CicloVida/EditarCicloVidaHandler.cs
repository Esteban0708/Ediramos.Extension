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
    public class EditarCicloVidaHandler : IRequestHandler<EditarCicloVidaCommand, int>
    {
        private readonly ICicloVidaRepository _repo;
        public EditarCicloVidaHandler(ICicloVidaRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(EditarCicloVidaCommand request, CancellationToken cancellationToken)
        {
            return await _repo.EditarCicloVidaAsync(
                request.DTO.IdCicloVida,
                request.DTO.Nombre
            );
        }
    }
}
