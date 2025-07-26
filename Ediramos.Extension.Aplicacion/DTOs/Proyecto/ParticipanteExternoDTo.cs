using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.Proyecto
{
    public class ParticipanteExternoDTo
    {
        public int IdUsuarioExterno { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Correo { get; set; }
        public string EPS { get; set; }
        public int IdProyecto { get; set; }
    }
}
