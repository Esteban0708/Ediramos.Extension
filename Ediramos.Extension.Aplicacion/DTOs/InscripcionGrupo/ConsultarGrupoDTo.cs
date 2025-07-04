using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.InscripcionGrupo
{
    public class ConsultarGrupoDto
    {
        public int IdGrupo { get; set; }
        public string Titulo { get; set; }
        public string AreaTrabajo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string EstadoActual { get; set; }
    }
}
