using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Dominio.Repositorios
{
    public interface IDivisionRepository
    {
        Task<int> CrearDivisionAsync(string nombre, string codigo, int fk_sesion);
        Task<List<Division>> ObtenerDivisionAsync();

        Task EliminarDivisionAsync(int id);
    }
}
