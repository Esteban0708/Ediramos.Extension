using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class ConsultarGrupo
    {
        public int IdGrupo { get; set; }
        public string Titulo { get; set; }
        public string AreaTrabajo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string EstadoActual { get; set; }
    }
}
