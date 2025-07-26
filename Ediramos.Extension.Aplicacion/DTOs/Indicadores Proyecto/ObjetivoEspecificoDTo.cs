using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.Indicadores_Proyecto
{
    public class ObjetivoEspecificoDTo
    {
        public int IdObjetivoEspecifico { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public int FK_IdProyecto { get; set; }
    }
}
