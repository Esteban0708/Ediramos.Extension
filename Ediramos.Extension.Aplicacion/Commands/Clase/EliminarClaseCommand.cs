using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Clase
{
    public class EliminarClaseCommand : IRequest<int>
    {
        public int IdClase { get; set; }
        public EliminarClaseCommand(int idClase)
        {
            IdClase = idClase;
        }
    }
}
