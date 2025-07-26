using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class DetalleProyectosUsuario
    {
        public List<ProyectoUsuario> Proyectos { get; set; }
        public List<ParticipanteInterno> ParticipantesInternos { get; set; }
        public List<ParticipanteExterno> ParticipantesExternos { get; set; }
        public List<SeguimientoProyecto> Seguimientos { get; set; }
    }
}
