using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.ObjetivoEspecifico;

namespace Ediramos.Extension.Aplicacion.DTOs.Indicadores_Proyecto
{
    public class IndicadoresProyectoDTo
    {
        public List<ObjetivoEspecificoDTo> ObjetivosEspecificos { get; set; }
        public List<AreaTrabajoDTo> AreasTrabajo { get; set; }
        public List<CicloVitalDTo> CiclosVida { get; set; }
        public List<PoblacionCondicionDTo> PoblacionesCondicion { get; set; }
        public List<GrupoProyectoDTo> GruposProyecto { get; set; }
    }
}
