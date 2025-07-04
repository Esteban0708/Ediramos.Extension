using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class LineaPorfundizacion
    {
        public int IdConvocatoria { get; set; }  

        public int IdLinea {  get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
    }
    public class LineaSP
    {
        public int IdConvocatoria { get; set; }
        public int IdLinea { get; set; }
        public string Nombre { get; set; }
    }
}
