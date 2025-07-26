using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class ProyectoUsuario
    {
        public int IdProyecto { get; set; }
        public string NombreProyecto { get; set; }
        public DateTime FechaPresentacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Duracion { get; set; }
        public string ObjetivoGeneral { get; set; }
        public string PlanteamientoProblema { get; set; }
        public string Metodologia { get; set; }
        public string Justificacion { get; set; }
        public string ComponenteInnovador { get; set; }
        public string PoblacionDirigida { get; set; }
        public string ResultadoAcciones3_1 { get; set; }
        public string Estado { get; set; }
        public int FK_IdConvocatoria { get; set; }
        public string TituloConvocatoria { get; set; }
        public string Descripcion { get; set; }
        public string EstadoConvocatoria { get; set; }
    }
}
