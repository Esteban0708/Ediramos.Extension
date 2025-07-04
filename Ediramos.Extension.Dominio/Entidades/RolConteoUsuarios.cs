using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Dominio.Entidades
{
    public class RolConteoUsuarios
    {
            public int IdRol { get; set; }
            public string NombreRol { get; set; }
            public int UsuariosAsignados { get; set; }
        }
    }
