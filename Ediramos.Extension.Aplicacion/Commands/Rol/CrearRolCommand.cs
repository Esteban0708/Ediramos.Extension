using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Rol
{
    public class CrearRolCommand :IRequest<bool>
    {
        public string Nombre { get; set; }
        public string ColorHex { get; set; }
        public List<int> Permisos { get; set; }

    }
}
