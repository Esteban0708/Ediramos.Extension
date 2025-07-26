using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class ProyectoCompleto
    {
        public string NombreProyecto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Duracion { get; set; }
        public string ObjetivoGeneral { get; set; }
        public string PlanteamientoProblema { get; set; }
        public string Metodologia { get; set; }
        public string Justificacion { get; set; }
        public string ComponenteInnovador { get; set; }
        public string PoblacionDirigida { get; set; }
        public string ResultadoAcciones { get; set; }
        public int? IdConvocatoria { get; set; }
        public bool Estado {  get; set; }
        public int IdGrupo { get; set; }
        public List<int> AreasTrabajo { get; set; }
        public List<int> CiclosVida { get; set; }
        public List<int> CondicionesPoblacion { get; set; }
        public List<int> GruposPoblacionales { get; set; }
        public List<ObjetivoEspecifico> ObjetivosEspecificos { get; set; }
        public List<ProductoPresupuesto> Productos { get; set; }
        public List<FuenteFinanciacion> Fuentes { get; set; }

    }
}
