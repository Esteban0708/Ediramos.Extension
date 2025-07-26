using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Proyecto;

namespace Ediramos.Extension.Aplicacion.DTOs.ObjetivoEspecifico
{
    public class ObjetivoEspecificoDTo
    {
        public string Descripcion { get; set; }
        public List<MetaDTo> Metas { get; set; }
    }
}
