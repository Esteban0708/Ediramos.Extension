using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.InscripcionGrupo
{
    public class ObtenerSemestreDTo
    {
        public int Pege_id { get; set; }
        public string Documento { get; set; }
        public int? Estp_semestreactual { get; set; }
    }
}
