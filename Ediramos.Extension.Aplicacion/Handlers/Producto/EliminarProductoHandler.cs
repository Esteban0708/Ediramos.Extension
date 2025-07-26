using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Producto;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Ediramos.Extension.Aplicacion.Handlers.Producto
{
    public class EliminarProductoHandler : IRequestHandler<EliminarProductoCommand, int>
    {
        private readonly IProductoRepository _repo;

        public EliminarProductoHandler(IProductoRepository repo) 
        {
            _repo = repo;
        }
        public async Task<int> Handle(EliminarProductoCommand request, CancellationToken cancellationToken)
        {
            await _repo.EliminarProductoAsync(request.IdProducto);
            return 1;
        }
    }
}
