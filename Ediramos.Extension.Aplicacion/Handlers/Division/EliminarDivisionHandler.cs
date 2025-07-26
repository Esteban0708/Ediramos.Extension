using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Division;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Division
{
    public class EliminarDivisionHandler : IRequestHandler<EliminarDivisionCommand, int>
    {
        private readonly IDivisionRepository _repo;
        public EliminarDivisionHandler(IDivisionRepository repo) {

            _repo = repo;
        }

        public async Task<int> Handle(EliminarDivisionCommand request, CancellationToken cancellationToken)
        {
            await _repo.EliminarDivisionAsync(request.IdDivision);
            return 1;
        }
    }
}
