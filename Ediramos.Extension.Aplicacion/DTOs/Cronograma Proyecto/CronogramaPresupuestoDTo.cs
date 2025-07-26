using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Proyecto;

namespace Ediramos.Extension.Aplicacion.DTOs.Cronograma_Proyecto
{
    public class CronogramaPresupuestoDTo
    {
        public List<CronogramaDTo> Cronograma { get; set; }
        public List<PresupuestoProductoDTo> PresupuestoProductos { get; set; }
        public List<FuenteFinanciacionDTo> FuentesFinanciacion { get; set; }
    }
}
