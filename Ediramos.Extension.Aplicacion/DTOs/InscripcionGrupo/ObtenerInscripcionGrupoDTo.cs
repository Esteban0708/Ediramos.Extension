using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Usuario;
using Ediramos.Extension.Aplicacion.DTOs.UsuarioExterno;

namespace Ediramos.Extension.Aplicacion.DTOs.InscripcionGrupo
{
    public class ObtenerInscripcionGrupoDTo
    {
        public int IdGrupo { get; set; }
        public string Titulo { get; set; }
        public string AreaTrabajo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string EstadoActual { get; set; }
        public string Observacion { get; set; }


        public List<ObtenerInforUsuarioDTo> Internos { get; set; } = new();
        public List<CrearUsuarioExternoDTo> Externos { get; set; } = new();
    }


}
