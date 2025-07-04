using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Usuario;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Usuario
{
    public class PrefijoUserCommnand : IRequest<List<UserPrefijoDTO>>
    {
        public string TextoBusqueda { get; set; }
    }

}
