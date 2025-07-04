using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Producto;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Producto
{
    public class ObtenerProductoHandler : IRequestHandler<ObtenerProductoQuery, List<ObtenerProductoDTo>>
    {
        private readonly IProductoRepository _repo;
        public ObtenerProductoHandler(IProductoRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<ObtenerProductoDTo>> Handle(ObtenerProductoQuery request, CancellationToken cancellationToken)
        {
            var productos = await _repo.ObtenerProductoAsync();
            return productos.Select(p => new ObtenerProductoDTo
            {
                IdProducto = p.IdProducto,
                Nombre = p.Nombre,
                Codigo = p.Codigo,
                Estado = p.Estado,
                fk_clase = p.fk_clase
            }).ToList();
        }
    }
}
