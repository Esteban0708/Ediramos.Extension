using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.PoblacionCondicion;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.PoblacionCondicion
{
    public class CrearPoblacionCommand : IRequest<int>
    {
        public CrearPoblacionCommand(CrearPoblacionDTo dto)
        {
            DTO = dto;
        }
        public CrearPoblacionDTo DTO { get; }
    }

}
