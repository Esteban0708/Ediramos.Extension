using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class Objetivo
    {
        public int IdConvocatoria { get; set; } 

        public int IdObjetivo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
    }
    public class ObjetivoSP
    {
        public int IdConvocatoria { get; set; }
        public int IdObjetivo { get; set; }
        public string Nombre { get; set; }
    }
}
