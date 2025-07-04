using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Modalidad;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Modalidad
{
    public class EditarModalidadCommand :IRequest<int>
    {
        public EditaModalidadDTo DTO { get; }
        public EditarModalidadCommand(EditaModalidadDTo dto)
        {
            DTO = dto;
        }
    }
}
