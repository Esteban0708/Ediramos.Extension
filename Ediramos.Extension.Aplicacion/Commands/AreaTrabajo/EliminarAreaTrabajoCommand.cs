using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.AreaTrabajo
{
    public class EliminarAreaTrabajoCommand : IRequest<int>
    {
        public int IdAreaTrabajo { get; }
        public EliminarAreaTrabajoCommand(int idAreaTrabajo)
        {
            IdAreaTrabajo = idAreaTrabajo;
        }
    }

}
