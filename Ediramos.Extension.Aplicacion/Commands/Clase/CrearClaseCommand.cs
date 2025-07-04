using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Clase;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Clase
{
    public class CrearClaseCommand : IRequest<int>
    {
        public CrearClaseDTo DTO { get; }
        public CrearClaseCommand(CrearClaseDTo dto)
        {
            DTO = dto;
        }
    }
}
