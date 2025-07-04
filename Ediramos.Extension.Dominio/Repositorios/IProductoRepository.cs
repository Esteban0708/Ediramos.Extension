using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Dominio.Repositorios
{
    public interface IProductoRepository
    {
        Task<int> CrearProductoAsync(string nombre, string codigo, int fk_clase);
        Task<List<Producto>> ObtenerProductoAsync();
        Task EliminarProductoAsync(int id);
    }
}
