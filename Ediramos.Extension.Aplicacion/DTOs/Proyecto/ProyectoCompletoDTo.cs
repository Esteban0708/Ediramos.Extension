using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.ObjetivoEspecifico;

namespace Ediramos.Extension.Aplicacion.DTOs.Proyecto
{
    public class ProyectoCompletoDTO
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
        public int IdGrupo { get; set; }
        public List<int> AreasTrabajo { get; set; }
        public List<int> CiclosVida { get; set; }
        public List<int> CondicionesPoblacion { get; set; }
        public List<int> GruposPoblacionales { get; set; }
        public List<ObjetivoEspecificoDTo> ObjetivosEspecificos { get; set; }
        public List<ProductoPresupuestoDTo> Productos { get; set; }
        public List<FuenteFinanciacionDTo> Fuentes { get; set; }
        public List<string> DocumentosInternos { get; set; }  
        public List<string> DocumentosExternos { get; set; }
        public string NombreGrupo { get; set; }
    }

}
