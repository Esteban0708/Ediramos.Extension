using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class ObtenerInscripcionGrupo
    {
        public int IdGrupo { get; set; }
        public string Titulo { get; set; }
        public string AreaTrabajo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
        public string DocumentoInterno { get; set; }
        public string DocumentoExterno { get; set; }

        public string NombreExterno { get; set; }
        public string EPS { get; set; }

        public bool? EsLider { get; set; }
    }
}
