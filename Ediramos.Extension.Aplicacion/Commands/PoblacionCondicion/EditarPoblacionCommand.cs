using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.PoblacionCondicion;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.PoblacionCondicion
{
    public class EditarPoblacionCommand : IRequest<int>
    {
        public EditarPoblacionCommand(EditarPoblacionDTo dto)
        {
            DTO = dto;
        }
        public EditarPoblacionDTo DTO { get; }
    }
}
