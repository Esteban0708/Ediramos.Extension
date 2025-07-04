using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Dominio.Repositorios
{
    public interface IPoblacionGrupoRepository
    {
        Task<int> CrearPoblacionGrupoAsync(string nombre);
        Task<List<PoblacionGrupo>> ObtenerPoblacionesGruposAsync();
        Task<int> EditarPoblacionGrupoAsync(int id, string nombre);
        Task<int> EliminarPoblacionGrupoAsync(int id);
    }
}
