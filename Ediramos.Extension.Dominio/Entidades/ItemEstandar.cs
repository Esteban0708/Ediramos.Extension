using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class ItemEstandar
    {
        public int IdItem { get; set; }
        public string Titulo { get; set; }
        public string Pregunta { get; set; }


    }
    public class ItemSP
    {
        public int IdConvocatoria { get; set; }
        public int IdItem { get; set; }
        public string Titulo { get; set; }
        public string Pregunta { get; set; }
        public int PuntajeMax { get; set; }
        public int PuntajeMin { get; set; }
    }
}
