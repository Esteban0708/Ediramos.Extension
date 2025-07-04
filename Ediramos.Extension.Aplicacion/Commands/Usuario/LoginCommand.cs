using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Objetivo;
using Ediramos.Extension.Aplicacion.DTOs.Usuario;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Usuario
{
    public class LoginCommand : IRequest<UsuarioDTO>
    {
        public string Correo { get; set; }
        public string Contraseña { get; set; }
    }
}
