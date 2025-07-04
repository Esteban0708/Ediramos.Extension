using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Dominio.Repositorios
{
    public interface IInforCoordinadorRepository
    {
        Task<List<InfoCoodinador>> ObtenerInformacionAsync(string documento);
        Task<List<Semestre>> ObtenerSemestreAsync(string documento);
    }
}
