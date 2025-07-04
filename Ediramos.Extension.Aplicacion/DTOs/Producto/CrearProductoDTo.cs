using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.Producto
{
    public class CrearProductoDTo
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int fk_clase { get; set; }

    }
}
