using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class Usuario
    {
        public int Pege_id { get; set; }

        public string Nombre { get; set; }
        public string Correo { get; set; }

        public string Documento { get; set; }
        public string Telefono { get; set; }
        public List<EstadoPersona> Estatus { get; set; }  

    }
}
