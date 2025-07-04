using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class UsuarioExterno
    {
        public long DocumentoIdentidad { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string EPS { get; set; }

    }
}
