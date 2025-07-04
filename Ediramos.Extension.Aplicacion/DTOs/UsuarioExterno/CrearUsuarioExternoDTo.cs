    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Ediramos.Extension.Aplicacion.DTOs.UsuarioExterno
    {
        public class CrearUsuarioExternoDTo
        {
            public long DocumentoIdentidad { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string Correo { get; set; }
            public string EPS { get; set; }

        }
    }
