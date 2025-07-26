using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.Cronograma_Proyecto
{
    public class CronogramaDTo
    {
        public int IdMeta { get; set; }
        public string MetaDescripcion { get; set; }
        public int FK_IdObjetivo { get; set; }
        public int IdActividad { get; set; }
        public string ActividadDescripcion { get; set; }
        public int FK_IdMeta { get; set; }
        public int IdPeriodo { get; set; }
        public string NombreSemana { get; set; }
    }
}
