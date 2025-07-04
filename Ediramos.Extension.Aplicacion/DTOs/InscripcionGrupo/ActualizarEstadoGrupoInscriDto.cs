using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.InscripcionGrupo
{
    public  class ActualizarEstadoGrupoInscriDto
    {
        public int IdGrupo { get; set; }
        public string Estado { get; set; } 
        public string Observacion { get; set; }
    }
}
