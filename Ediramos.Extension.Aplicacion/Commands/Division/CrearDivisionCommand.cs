using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Division;
using Ediramos.Extension.Aplicacion.DTOs.Sesion;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Division
{
   public class CrearDivisionCommand : IRequest<int>
    {
        public CrearDivisionDTO DTO { get; }
        public CrearDivisionCommand(CrearDivisionDTO dto)
        {
            DTO = dto;
        }
    }
}
