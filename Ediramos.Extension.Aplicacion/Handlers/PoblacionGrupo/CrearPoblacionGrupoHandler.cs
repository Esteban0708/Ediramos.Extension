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
    public class CrearPoblacionGrupoHandler : IRequestHandler<CrearPoblacionGrupoCommand, int>
    {
        private readonly IPoblacionGrupoRepository _repo;
        public CrearPoblacionGrupoHandler(IPoblacionGrupoRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(CrearPoblacionGrupoCommand request, CancellationToken cancellationToken)
        {
            return await _repo.CrearPoblacionGrupoAsync(
                request.DTO.Nombre
            );
        }
    }
}
