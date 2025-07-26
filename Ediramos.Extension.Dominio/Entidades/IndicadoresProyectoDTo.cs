using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Aplicacion.DTOs.Indicadores_Proyecto
{
    public class IndicadoresProyectoDTo
    {
        public List<ObjetivoEspecificoProyecto> ObjetivosEspecificos { get; set; }
        public List<AreaTrabajo> AreasTrabajo { get; set; }
        public List<CicloVida> CiclosVida { get; set; }
        public List<PoblacionCondicion> PoblacionesCondicion { get; set; }
        public List<GrupoProyecto> GruposProyecto { get; set; }
    }
}
