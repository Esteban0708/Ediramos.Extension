using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Rol
{
    public class EliminarRolCommand : IRequest<int>
    {
        public int IdRol { get; }
        public EliminarRolCommand(int idRol)
        {
            IdRol = idRol;
        }
    }
}
