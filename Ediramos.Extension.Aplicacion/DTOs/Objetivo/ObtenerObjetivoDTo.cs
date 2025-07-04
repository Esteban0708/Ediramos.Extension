using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.Objetivo
{
    public class ObtenerObjetivoDTO
    {
        public int IdObjetivo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
    }

    public class ObjetivoDto
    {
        public int IdObjetivo { get; set; }
        public string Nombre { get; set; }
    }

}
