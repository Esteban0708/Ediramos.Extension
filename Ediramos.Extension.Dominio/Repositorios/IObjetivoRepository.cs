using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Dominio.Repositorios
{
    public interface IObjetivoRepository
    {
        Task<int> CrearObjetivoAsync(string nombre, string descripcion);
        Task<List<Objetivo>> ObtenerObjetivosAsync();
        Task<int> EditarObjetivoAsync(int id, string nombre, string descripcion);
        Task<int> EliminarObjetivoAsync(int idObjetivo);
    }
}
