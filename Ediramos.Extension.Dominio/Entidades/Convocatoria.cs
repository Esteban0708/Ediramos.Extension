using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class Convocatoria
    {
        public int IdConvocatoria { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Resolucion { get; set; }
        public string NResolucion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Duracion { get; set; }
        public int Estado { get; set; }
        public int? IdModalidad { get; set; }
        public string Modalidad { get; set; }

        public List<ObjetivoSP> Objetivos { get; set; } = new();
        public List<LineaSP> Lineas { get; set; } = new();
        public List<ItemSP> Items { get; set; } = new();
    }
}
