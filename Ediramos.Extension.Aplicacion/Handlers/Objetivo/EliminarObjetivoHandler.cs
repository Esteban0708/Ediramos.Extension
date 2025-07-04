using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Objetivo;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Objetivo
{
    public class EliminarObjetivoHandler : IRequestHandler<EliminarObjetivoCommand, int>
    {
        private readonly IObjetivoRepository _repository;

        public EliminarObjetivoHandler(IObjetivoRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(EliminarObjetivoCommand request, CancellationToken cancellationToken)
        {
            return await _repository.EliminarObjetivoAsync(request.IdObjetivo);
        }
    }

}
