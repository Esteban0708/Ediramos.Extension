using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Dominio.Repositorios
{
    public interface ISesionRepository
    {
        Task<int> CrearSesionAsync(string nombre, string codigo);
        Task<List<Sesion>> ObtenerSesionesAsync();

        Task EliminarSesionAsync(int id); 

    }
}
