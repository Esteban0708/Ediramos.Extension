using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.Evaluador
{
    public class AsignarEvaluadorDTo
    {
        public int IdProyecto { get; set; }
        public int PEGE_ID { get; set; }
        public string Documento { get; set; }
        public string NombreCompleto { get; set; }
        public int IdTipoJurado { get; set; }
    }
}
