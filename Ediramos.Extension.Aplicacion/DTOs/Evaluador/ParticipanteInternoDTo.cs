using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.Evaluador
{
    public class ParticipanteInternoDTo
    {
        public int PegeId { get; set; }
        public string NombreCompleto { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string TipoVinculacion { get; set; }
        public int IdGrupo { get; set; }
        public string TituloGrupo { get; set; }
        public bool EsLider { get; set; }
        public int IdProyecto { get; set; }
    }
}
