using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Aplicacion.DTOs.Evaluador
{
    public class ProyectoJuradoCompletoDTo
    {
        public ProyectoJuradoDTo Proyecto { get; set; }
        public List<ParticipanteInternoDTo> ParticipantesInternos { get; set; }
        public List<ParticipanteExternoDTo> ParticipantesExternos { get; set; }
    }
}
