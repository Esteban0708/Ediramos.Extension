using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Dominio.Repositorios
{
    public interface IRolRepository
    {
        Task CrearRolAsync(string nombre, string colorHex, List<int> permisos);
        Task<List<Rol>> ObtenerPermisoRolAsync();
        Task<bool> ActualizarRolAsync(int idRol, string nombreRol, string colorHex, List<int> permisos); 

        Task<int> EliminarRolAsync(int idRol);

        Task<List<RolConteoUsuarios>> ContarUsuariosPorRolAsync();

        Task<List<ObtenerUsuarioRol>> ObtenerUsuarioRolAsync(int IdRol);
        Task<bool> DesactivarUsuarioRolAsync(int pegeId, int idRol);

    }
}
