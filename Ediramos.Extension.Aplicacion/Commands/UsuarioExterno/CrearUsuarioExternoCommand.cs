using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.UsuarioExterno;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.UsuarioExterno
{
    public class CrearUsuarioExternoCommand : IRequest<int>
    {
        public CrearUsuarioExternoDTo DTO { get; }
        public CrearUsuarioExternoCommand(CrearUsuarioExternoDTo dto)
        {
            DTO = dto;
        }

    }
}
