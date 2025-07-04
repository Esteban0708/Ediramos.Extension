using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.Linea
{
    public class ObtenerLineaDTo
    {
        public int IdLineaProfundizacion {  get; set; }
        public string Nombre { get; set; }

        public int Estado { get; set; }
    }
}
