using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.AreTrabajo;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.AreaTrabajo
{
    public class EditarAreaTrabajoCommand : IRequest<int>
    {
        public EditarAreaTrabajoDTo DTO { get; }
        public EditarAreaTrabajoCommand(EditarAreaTrabajoDTo dto)
        {
            DTO = dto;
        }
    }

}
