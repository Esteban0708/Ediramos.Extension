using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class SeguimientoProyecto
    {
        public int IdSeguimientoProyecto { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
        public int FK_IdProyecto { get; set; }
    }
}
