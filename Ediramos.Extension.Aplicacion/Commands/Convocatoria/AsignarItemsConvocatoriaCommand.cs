using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Convocatoria;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Convocatoria
{
    public class AsignarItemsConvocatoriaCommand : IRequest<bool>
    {
        public AsignarItemsConvocatoriaDto DTO { get; }

        public AsignarItemsConvocatoriaCommand(AsignarItemsConvocatoriaDto dto)
        {
            DTO = dto;
        }
    }
}
