using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class PresupuestoProducto
    {
        public int IdPresupuesto { get; set; }
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Total { get; set; }
        public int Cantidad { get; set; }
        public string NombreUnidad { get; set; }
        public string DescripcionUnidad { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
