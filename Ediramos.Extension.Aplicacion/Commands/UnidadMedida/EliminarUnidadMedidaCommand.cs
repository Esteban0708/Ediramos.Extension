using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.UnidadMedida
{
    public class EliminarUnidadMedidaCommand : IRequest<int>
    {
        public int UnidadMedida { get; set; }
        public EliminarUnidadMedidaCommand(int unidadMedida)
        {
            UnidadMedida = unidadMedida;
        }
    }
}
