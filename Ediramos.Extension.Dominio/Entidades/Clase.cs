using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class Clase
    {
        public int IdClase { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public bool Estado { get; set; }
        public int fk_grupo { get; set; }
     
    }
}
