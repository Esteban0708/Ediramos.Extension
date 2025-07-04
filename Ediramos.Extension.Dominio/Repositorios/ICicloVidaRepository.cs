using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Dominio.Repositorios
{
    public interface ICicloVidaRepository
    {
        Task<int> CrearCicloVidaAsync(string nombre);
        Task<List<CicloVida>> ObtenerCicloVidaAsync();
        Task<int> EditarCicloVidaAsync(int id, string nombre);
        Task<int> EliminarCicloVidaAsync(int id);
    }
}
