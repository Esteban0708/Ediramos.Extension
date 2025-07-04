using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Permisos;

namespace Ediramos.Extension.Aplicacion.DTOs.RolPermisos
{
    public class ObtenerPermisosRolDTo
    {
        public int IdRol {  get; set; }
        public string NombreRol { get; set; }
        public string ColorHex { get; set; }
        public List<ObtenerPermisosDTo> Permisos {  get; set; }

    }
}
