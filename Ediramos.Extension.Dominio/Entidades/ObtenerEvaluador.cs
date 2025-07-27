using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class ObtenerEvaluador
    {
        public int PegeId { get; set; }
        public string NombreCompleto { get; set; }
        public string Documento { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaLimite { get; set; }
        public int IdProyecto { get; set; }
    }
}
