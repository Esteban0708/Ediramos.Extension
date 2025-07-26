using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.UnidadMedida
{
    public class ObtenerUnidadMedidaDTo
    {
        public int IdUnidadMedida { get; set; }
        public string Nombre { get; set; }
        public string Descripcion {  get; set; }
        public bool Estado {  get; set; }
    }
}
