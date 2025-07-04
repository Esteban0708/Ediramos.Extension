using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.InscripcionGrupo
{
    public class ObtenerHistorialGrupoDTo
    {
        public int IdGrupo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Titulo { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
        public bool EsLider { get; set; }
        public DateTime FechaEstado { get; set; }
        public string DescripcionAreaTrabajo { get; set; }
        public List<InternoDTo> Internos { get; set; }
        public List<ExternoDto> Externos { get; set; }
    }
}
