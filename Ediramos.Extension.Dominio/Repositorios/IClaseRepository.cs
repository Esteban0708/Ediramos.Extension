using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Dominio.Repositorios
{
    public interface IClaseRepository
    {
        Task<int> CrearClaseAsync(string nombre, string codigo, int fk_grupo);
        Task<List<Clase>> ObtenerClaseAsync();
        Task EliminarClaseAsync(int id);
    }
}
