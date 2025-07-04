using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.RolPermisos;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Rol
{
    public class AsignarRolUsuarioCommand : IRequest
    {
        public AsignarRolUsuarioDto Dto { get; }
        public AsignarRolUsuarioCommand(AsignarRolUsuarioDto dto)
        {
           Dto = dto;
        }
    }
}
