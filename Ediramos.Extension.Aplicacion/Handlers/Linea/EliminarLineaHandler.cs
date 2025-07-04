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
    public class EliminarLineaHandler : IRequestHandler<EliminarLineaCommand, int>
    {
        private readonly ILineaRepository _repository; 

        public EliminarLineaHandler(ILineaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(EliminarLineaCommand request, CancellationToken cancellationToken)
        {
            return await _repository.EliminarLineaAsync(request.IdLineaProfundizacion);
        }
    }
}
