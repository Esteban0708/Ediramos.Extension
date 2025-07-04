using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class HistorialGrupo
    {
        public int IdGrupo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Titulo { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }

        public bool EsLider { get; set; }
        public DateTime FechaEstado { get; set; }
        public string DescripcionAreaTrabajo { get; set; }
        public List<ConsultarInterno> Internos { get; set; }
        public List<ConsultarExterno> Externos { get; set; }
    }
}
