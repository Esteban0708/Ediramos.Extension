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
    public class EditarLineaHandler : IRequestHandler<EditarLineaCommand, int>
    {
        private readonly ILineaRepository _repository;
        public EditarLineaHandler(ILineaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(EditarLineaCommand request, CancellationToken cancellationToken)
        {
            var dto = request.DTO;
            return await _repository.EditarLineaAsync(
                dto.IdLineaProfundizacion,
                dto.Nombre
            );
        }
    }
}
