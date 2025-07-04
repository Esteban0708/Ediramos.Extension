using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Sesion;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Sesion
{
    public class CrearSesionCommand : IRequest<int>
    {
        public CrearSesionDTO DTO { get; }
        public CrearSesionCommand(CrearSesionDTO dto)
        {
            DTO = dto;
        }
    }
}
