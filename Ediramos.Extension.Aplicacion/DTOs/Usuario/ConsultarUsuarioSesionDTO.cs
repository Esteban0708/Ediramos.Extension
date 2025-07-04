using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Sesion;

namespace Ediramos.Extension.Aplicacion.DTOs.Usuario
{
    public class UsuarioDTO
    {
        public int PEGE_ID{ get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public List<EstadoPersonaDTO> Estatus{ get; set; }  
    }

}
