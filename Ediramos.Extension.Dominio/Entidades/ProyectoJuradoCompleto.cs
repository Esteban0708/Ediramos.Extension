using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class ProyectoJuradoCompleto
    {
        public ProyectoJurado Proyecto { get; set; }
        public List<ParticipanteInterno> ParticipantesInternos { get; set; }
        public List<ParticipanteExterno> ParticipantesExternos { get; set; }
    }
}
