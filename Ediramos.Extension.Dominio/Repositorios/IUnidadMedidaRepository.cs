using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Dominio.Repositorios
{
    public interface IUnidadMedidaRepository
    {
        Task<int> CrearUnidadMedidaAsync(string Nombre, string Descripcion);
        Task<List<UnidadMedida>> ObtenerUnidadMedidaAsync(); 
    }
}
