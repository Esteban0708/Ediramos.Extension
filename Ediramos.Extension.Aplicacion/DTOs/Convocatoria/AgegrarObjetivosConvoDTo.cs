using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.Convocatoria
{
    public class AgegrarObjetivosConvoDTo
    {
        public int IdConvocatoria { get; set; }
        public List<int> Objetivos { get; set; } = new List<int>();
    }
}
