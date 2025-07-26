using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.Proyecto
{
    public class DetalleProyectosUsuarioDTo
    {
        public List<ProyectoUsuarioDTo> Proyectos { get; set; }
        public List<ParticipanteInternoDTo> ParticipantesInternos { get; set; }
        public List<ParticipanteExternoDTo> ParticipantesExternos { get; set; }
        public List<SeguimientoProyectoDTo> Seguimientos { get; set; }
    }
}
