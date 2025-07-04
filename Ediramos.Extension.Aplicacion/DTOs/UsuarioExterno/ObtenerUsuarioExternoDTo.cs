using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.UsuarioExterno
{
    public class ObtenerUsuarioExternoDTo
    {
        public string DocumentoParcial { get; set; } = string.Empty; 

        public long DocumentoIdentidad { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string EPS { get; set; } = string.Empty;
    }
}
