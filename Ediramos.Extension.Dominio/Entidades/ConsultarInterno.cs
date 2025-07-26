using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class ConsultarInterno
    {
        public int IdGrupo { get; set; }
        public string DocumentoIdentidad { get; set; }
        public bool? EsLider { get; set; }
        public string TipoVinculacion { get; set; }
    }
}
