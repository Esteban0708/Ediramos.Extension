using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Modalidad
{
    public class EliminarModalidadCommand : IRequest<int>
    {
        public int IdModalidad { get; }
        public EliminarModalidadCommand(int idModalidad)
        {
            IdModalidad = idModalidad;
        }
    }
}
