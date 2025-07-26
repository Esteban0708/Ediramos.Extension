using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class FuenteFinanciacion
    {
        public int IdFuenteFinanciacion { get; set; }

        public string Entidad { get; set; }
        public float Valor { get; set; }
        public bool Estado { get; set; }

    }
}
