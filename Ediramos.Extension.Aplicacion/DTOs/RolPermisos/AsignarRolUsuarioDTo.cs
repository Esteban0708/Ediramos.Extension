using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.RolPermisos
{
    public class AsignarRolUsuarioDto
    {
        public int PegeId { get; set; }
        public string NombreCompleto { get; set; }
        public string DocumentoIdentidad { get; set; }
        public int IdRol { get; set; }
    }

}
