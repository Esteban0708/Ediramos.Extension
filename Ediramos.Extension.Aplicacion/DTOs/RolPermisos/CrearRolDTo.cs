using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.RolPermisos
{
    public class CrearRolDTo
    {
        public string Nombre { get; set; }
        public string ColorHex { get; set; }
        public List<int> Permisos { get; set; } = new List<int>();
    }
}
