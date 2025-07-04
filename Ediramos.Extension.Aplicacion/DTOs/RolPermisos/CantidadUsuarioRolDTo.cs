using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.RolPermisos
{
    public class CantidadUsuarioRolDTo
    {
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public int UsuarioAsignados { get; set; }
    }
}
