using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Linea;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Linea
{
    public class CrearLineaCommand : IRequest<int>
    {
        public CrearLineaDTo DTO { get; }
        public CrearLineaCommand(CrearLineaDTo dto)
        {
            DTO = dto;
        }
    }
}
