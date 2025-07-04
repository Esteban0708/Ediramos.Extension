using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Dominio.Repositorios
{
    public interface IPoblacionRepository
    {
        Task<int> CrearPoblacionAsync(string nombre);
        Task<List<PoblacionCondicion>> ObtenerPoblacionAsync();
        Task<int> EditarPoblacionAsync(int id, string nombre);
        Task<int> EliminarPoblacionAsync(int id);
    }
}
