using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Linea;
using Ediramos.Extension.Aplicacion.DTOs.Objetivo;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Aplicacion.DTOs.Convocatoria
{
    public class ObtenerConvocatoriaDTo
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
        public string ModalidadNombre { get; set; }
        public List<ObjetivoDto> Objetivos { get; set; } = new();
        public List<ObtenerLineaDTo> Lineas { get; set; } = new();
        public List<obtenerItemDto> Items { get; set; } = new();
    }

}
