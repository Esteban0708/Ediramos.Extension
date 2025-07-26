using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class ArchivoDescargado
    {
        public byte[] Contenido { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
    }

}
