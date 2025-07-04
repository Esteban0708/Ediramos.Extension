using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.InscripcionGrupo
{
    public class ExternoDto
    {
        public int IdGrupo { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string NombreCompleto { get; set; }
        public string EPS { get; set; }
        public string Correo { get; set; }
    }
}
