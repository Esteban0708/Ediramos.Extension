using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.PoblacionCondicion
{
    public class EliminarPoblacionCommand : IRequest<int>
    {
        public int IdPoblacion { get; }
        public EliminarPoblacionCommand(int idPoblacion)
        {
            IdPoblacion = idPoblacion;
        }
    }

}
