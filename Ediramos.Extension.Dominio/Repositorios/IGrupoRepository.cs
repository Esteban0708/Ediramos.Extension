using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Dominio.Repositorios
{
    public interface IGrupoRepository
    {
        Task<int> CrearGrupoAsync(string nombre, string codigo, int fk_division);
        Task<List<Grupo>> ObtenerGrupoAsync();

        Task EliminarGruponAsync(int id);
    }
}
