using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Dominio.Repositorios
{
    public interface IUsuarioExternoRepository
    {
        Task<int> CrearUsuarioExternoAsync(
            long documentoIdentidad,
            string nombres,
            string apellidos,
            string correo,
            string eps
        );
        Task<List<UsuarioExterno>> ObtenerUsuarioExternoAsync(string documentoParcial);
    }
}
