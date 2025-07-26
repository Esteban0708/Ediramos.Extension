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
    public class EliminarClaseHandler : IRequestHandler<EliminarClaseCommand, int>
    {
        private readonly IClaseRepository _repo;
        public EliminarClaseHandler(IClaseRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(EliminarClaseCommand request, CancellationToken cancellationToken)
        {
            await _repo.EliminarClaseAsync(request.IdClase);
            return 1; 
        }
    }
}
