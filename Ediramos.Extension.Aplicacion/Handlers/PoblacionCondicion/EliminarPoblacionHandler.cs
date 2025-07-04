using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.PoblacionCondicion;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.PoblacionCondicion
{
    public class EliminarPoblacionHandler : IRequestHandler<EliminarPoblacionCommand, int>
    {
        private readonly IPoblacionRepository _repository;
        public EliminarPoblacionHandler(IPoblacionRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(EliminarPoblacionCommand request, CancellationToken cancellationToken)
        {
            return await _repository.EliminarPoblacionAsync(request.IdPoblacion);
        }
    }
}
