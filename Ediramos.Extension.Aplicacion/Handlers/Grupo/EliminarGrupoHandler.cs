using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Grupo;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Grupo
{
    public class EliminarGrupoHandler : IRequestHandler<EliminarGrupoCommand, int>
    { 
        private readonly IGrupoRepository _repository;

        public EliminarGrupoHandler(IGrupoRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(EliminarGrupoCommand request, CancellationToken cancellationToken)
        {
            await _repository.EliminarGruponAsync(request.IdGrupo);
            return 1;
        }
    }
}
