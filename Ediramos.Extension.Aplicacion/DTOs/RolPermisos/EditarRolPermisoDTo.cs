using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.RolPermisos
{
    public class EditarRolPermisoDTo
    {
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public string ColorHex { get; set; }
        public List<int> Permisos { get; set; }
    }
}
