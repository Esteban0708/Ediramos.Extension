using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Linea
{
    public class EliminarLineaCommand : IRequest<int>
    {
        public int IdLineaProfundizacion { get; }
        public EliminarLineaCommand(int idLineaProfundizacion)
        {
            IdLineaProfundizacion = idLineaProfundizacion;
        }
    }
}
