using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Dominio.Repositorios
{
    public interface IAreaTrabajoRepository
    {
        Task<int> CrearAreaTrabajoAsync(string nombre);
        Task<List<AreaTrabajo>> ObtenerAreasTrabajoAsync();
        Task<int> EditarAreaTrabajoAsync(int id, string nombre);
        Task<int> EliminarAreaTrabajoAsync(int id);
    }
}
