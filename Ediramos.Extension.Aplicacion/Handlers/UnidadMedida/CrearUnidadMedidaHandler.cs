using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.UnidadMedida;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.UnidadMedida
{
    public class CrearUnidadMedidaHandler :IRequestHandler<CrearUnidadMedidaCommand, int>
    {
        private readonly IUnidadMedidaRepository _repo; 

        public CrearUnidadMedidaHandler(IUnidadMedidaRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(CrearUnidadMedidaCommand request, CancellationToken cancellationToken)
        {
            return await _repo.CrearUnidadMedidaAsync(
                request.DTO.Nombre, 
                request.DTO.Descripcion
                );
        }
    }
}
