using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Producto;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Producto
{
    public class CrearProductoHandler : IRequestHandler<CrearProductoCommand, int>
    {
        private readonly IProductoRepository _repo;
        public CrearProductoHandler(IProductoRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(CrearProductoCommand request, CancellationToken cancellationToken)
        {
            return await _repo.CrearProductoAsync(
                request.DTO.Nombre,
                request.DTO.Codigo,
                request.DTO.fk_clase
            );
        }
    }
}
