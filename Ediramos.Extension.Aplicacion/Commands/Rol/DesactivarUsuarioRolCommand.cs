using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.RolPermisos;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Rol
{
    public class DesactivarUsuarioRolCommand : IRequest<bool>
    {
        public int PegeId { get; set; }
        public int IdRol { get; set; }

        public DesactivarUsuarioRolCommand(DesactivarUsuarioRolDto dto)
        {
            PegeId = dto.PegeId;
            IdRol = dto.IdRol;
        }
    }
}
