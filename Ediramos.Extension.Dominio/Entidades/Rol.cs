using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public string ColorHex { get; set; }
        public int IdPermiso { get; set; }
        public string? NombrePermiso { get; set; }
    }
}
