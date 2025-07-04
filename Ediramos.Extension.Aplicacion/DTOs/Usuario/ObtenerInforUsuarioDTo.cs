using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.Usuario
{
    public class ObtenerInforUsuarioDTo
    {
        public int Pege_id { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public string Dependencia { get; set; }

        public string Programa { get; set; }

        public string Eps { get; set; }

        public string Estatus { get; set; }
        public bool EsLider { get; set; }
    }
}
