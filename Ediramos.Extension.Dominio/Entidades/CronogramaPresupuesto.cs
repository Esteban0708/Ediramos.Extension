using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class CronogramaPresupuesto
    {
        public List<Cronograma> Cronograma { get; set; }
        public List<PresupuestoProducto> PresupuestoProductos { get; set; }
        public List<FuenteFinanciacion> FuentesFinanciacion { get; set; }
    }
}
