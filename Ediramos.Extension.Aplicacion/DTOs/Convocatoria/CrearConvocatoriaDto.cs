using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.Convocatoria
{
    public class CrearConvocatoriaDto
    {
        public string Titulo { get; set; }
        public string Resolucion { get; set; }
        public string NResolucion { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Duracion { get; set; }
        public int? Modalidad { get; set; }
        public List<int> Objetivos { get; set; }
        public List<int> Lineas { get; set; }
    }

}
