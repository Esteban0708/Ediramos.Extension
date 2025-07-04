using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Division;
using Ediramos.Extension.Aplicacion.Commands.Sesion;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Division
{
    public class CrearDivisionHandler : IRequestHandler<CrearDivisionCommand, int>
    {
        private readonly IDivisionRepository _repo;
        public CrearDivisionHandler(IDivisionRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(CrearDivisionCommand request, CancellationToken cancellationToken)
        {
            return await _repo.CrearDivisionAsync(
                request.DTO.Nombre,
                request.DTO.Codigo,
                request.DTO.fk_sesion
            );
        }
    }
}
