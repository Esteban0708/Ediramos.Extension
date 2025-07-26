using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Producto
{
    public class EliminarProductoCommand : IRequest<int>
    {
        public int IdProducto { get; set; }
        public EliminarProductoCommand(int idProducto)
        {
            IdProducto = idProducto;
        }
    }
}
