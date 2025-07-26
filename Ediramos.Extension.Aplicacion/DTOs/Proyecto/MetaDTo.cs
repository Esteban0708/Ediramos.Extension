using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.Proyecto
{
    public class MetaDTo
    {
        public int IdMeta { get; set; }
        public string Descripcion { get; set; }
        public List<ActividadDTo> Actividades { get; set; }
    }
}
