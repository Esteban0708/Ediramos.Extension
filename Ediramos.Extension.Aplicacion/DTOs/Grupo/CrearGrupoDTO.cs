using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.Grupo
{
    public class CrearGrupoDTO
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int fk_division { get; set; }
    }
}
