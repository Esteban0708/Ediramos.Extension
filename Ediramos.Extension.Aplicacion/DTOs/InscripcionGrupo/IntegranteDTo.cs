using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.InscripcionGrupo
{
    public class IntegranteDTo
    {
        public int Pege_id { get; set; }
        public string Documento { get; set; }
        public string NombreCompleto { get; set; }
        public bool EsLider { get; set; }
        public string TipoVinculacion { get; set; }

    }
}
