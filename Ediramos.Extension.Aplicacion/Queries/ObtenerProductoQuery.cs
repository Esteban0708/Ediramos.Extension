using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Producto;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{
    public class ObtenerProductoQuery : IRequest<List<ObtenerProductoDTo>>
    {
        public ObtenerProductoQuery()
        {
        }
    }
}
