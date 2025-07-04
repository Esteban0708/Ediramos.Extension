using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Division;
using Ediramos.Extension.Aplicacion.Commands.Grupo;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Grupo
{
    public class CrearGrupoHandler : IRequestHandler<CrearGrupoCommand, int>
    {
        private readonly IGrupoRepository _repo;
        public CrearGrupoHandler(IGrupoRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(CrearGrupoCommand request, CancellationToken cancellationToken)
        {
            return await _repo.CrearGrupoAsync(
                request.DTO.Nombre,
                request.DTO.Codigo,
                request.DTO.fk_division
            );
        }
    }
}
