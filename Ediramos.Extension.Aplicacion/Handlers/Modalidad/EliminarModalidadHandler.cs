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
    public class EliminarModalidadHandler : IRequestHandler<EliminarModalidadCommand, int>
    {
        private readonly IModalidadRepository _repository;
        public EliminarModalidadHandler(IModalidadRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(EliminarModalidadCommand request, CancellationToken cancellationToken)
        {
            return await _repository.EliminarModalidadAsync(request.IdModalidad);
        }
    }
}
