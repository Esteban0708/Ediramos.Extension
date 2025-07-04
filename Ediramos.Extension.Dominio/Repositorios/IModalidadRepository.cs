using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Dominio.Repositorios
{
    public interface IModalidadRepository
    {
        Task<int> CrearModalidadAsync(string nombre);
        Task<List<Modalidad>> ObtenerModalidadesAsync();
        Task<int> EditarModalidadAsync(int id, string nombre);
        Task<int> EliminarModalidadAsync(int id);
    }
}
