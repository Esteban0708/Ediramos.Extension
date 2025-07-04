using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.UnidadMedida;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.UnidadMedida
{
    public class CrearUnidadMedidaCommand : IRequest<int>
    {
        public CrearUnidadMedidaDTo DTO { get; }
        public CrearUnidadMedidaCommand(CrearUnidadMedidaDTo dTO)
        {
            DTO = dTO;
        }
    }
}
