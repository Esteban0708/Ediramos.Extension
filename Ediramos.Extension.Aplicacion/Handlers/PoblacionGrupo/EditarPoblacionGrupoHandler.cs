using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.PoblacionGrupo;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.PoblacionGrupo
{
    public class EditarPoblacionGrupoHandler : IRequestHandler<EditarPoblacionGrupoCommand, int>
    {
        private readonly IPoblacionGrupoRepository _repository;
        public EditarPoblacionGrupoHandler(IPoblacionGrupoRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(EditarPoblacionGrupoCommand request, CancellationToken cancellationToken)
        {
            var dto = request.DTO;
            return await _repository.EditarPoblacionGrupoAsync(
                dto.IdGrupo,
                dto.Nombre
            );
        }
    }
}
