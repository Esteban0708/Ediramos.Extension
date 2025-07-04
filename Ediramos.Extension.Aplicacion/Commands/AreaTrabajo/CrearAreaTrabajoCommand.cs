using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.AreTrabajo;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.AreaTrabajo
{
    public class CrearAreaTrabajoCommand : IRequest<int>
    {
        public CrearAreaTrabajoDTo DTO { get; }
        public CrearAreaTrabajoCommand(CrearAreaTrabajoDTo dto)
        {
            DTO = dto;
        }
    }

}
