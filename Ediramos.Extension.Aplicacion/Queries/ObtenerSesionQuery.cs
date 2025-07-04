using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Sesion;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{
    public class ObtenerSesionQuery : IRequest<List<ObtenerSesionDTo>>
    {
        public ObtenerSesionQuery()
        {
        }
    
    }
}
