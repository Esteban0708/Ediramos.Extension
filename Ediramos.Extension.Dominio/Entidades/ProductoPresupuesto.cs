using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class ProductoPresupuesto
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public int IdUnidadMedida { get; set; }
        public float ValorUnitario { get; set; }
    }
}
