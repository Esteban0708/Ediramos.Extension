using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Linea;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Linea
{
    public class EditarLineaCommand :IRequest<int>
    {
        public EditarLineaDTo DTO { get; }

        public EditarLineaCommand(EditarLineaDTo dto)
        {
            DTO = dto;
        }
    }
}
