using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.Convocatoria
{
    public class ItemDto
    {
        public string Titulo { get; set; }
        public string Pregunta { get; set; }
        public bool EsEstandar { get; set; }
        public bool Estado { get; set; }
        public float PuntajeMax { get; set; }
        public float PuntajeMin { get; set; }
    }
    public class AsignarItemsConvocatoriaDto
    {
        public int IdConvocatoria { get; set; }
        public List<ItemDto> Items { get; set; }
    }
    public class obtenerItemDto
    {
        public int IdItem { get; set; }
        public string Titulo { get; set; }
        public string Pregunta { get; set; }
        public int PuntajeMax { get; set; }
        public int PuntajeMin { get; set; }
    }
}
    