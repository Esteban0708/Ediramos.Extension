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
    public class EditarModalidadHandler : IRequestHandler<EditarModalidadCommand, int>
    {
        private readonly IModalidadRepository _repository; 

        public EditarModalidadHandler(IModalidadRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(EditarModalidadCommand request, CancellationToken cancellationToken)
        {
            var dto = request.DTO;
            return await _repository.EditarModalidadAsync(
                dto.IdModalidad,
                dto.Nombre
            );
        }
    }
}
