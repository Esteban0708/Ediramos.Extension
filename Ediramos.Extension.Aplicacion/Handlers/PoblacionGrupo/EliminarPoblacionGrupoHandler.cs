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
    public class EliminarPoblacionGrupoHandler : IRequestHandler<EliminarPoblacionGrupoCommand, int>
    {
        private readonly IPoblacionGrupoRepository _repository;
        public EliminarPoblacionGrupoHandler(IPoblacionGrupoRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(EliminarPoblacionGrupoCommand request, CancellationToken cancellationToken)
        {
            return await _repository.EliminarPoblacionGrupoAsync(request.IdGrupo);
        }
    }
}
