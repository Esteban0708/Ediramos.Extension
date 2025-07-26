using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Sesion
{
    public class EliminarSesionCommand : IRequest<int>
    {
        public int IdSesion { get; set; }
        public EliminarSesionCommand(int idSesion)
        {
            IdSesion = idSesion;
        }
    }
}
