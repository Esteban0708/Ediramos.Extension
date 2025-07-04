using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.Sesion
{
    public class ObtenerSesionDTo
    {
        public int IdSesion { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public bool Estado { get; set; }  
    }

}
