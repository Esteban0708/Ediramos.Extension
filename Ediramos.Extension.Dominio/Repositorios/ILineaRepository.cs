using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Dominio.Repositorios
{
    public interface ILineaRepository
    {
        Task<int> CrearLineaAsync(string nombre);
        Task<List<LineaPorfundizacion>> ObtenerLineasAsync();
        Task<int> EditarLineaAsync (int id, string nombre);
        Task<int> EliminarLineaAsync(int id);
    }
}
