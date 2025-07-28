using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Dominio.Repositorios
{
    public interface IEvaluadorRespository
    {
        Task<bool> AsignarEvaluadorAsync(AsignarEvaluador evaluador);
        Task<List<ObtenerEvaluador>> ObtenerEvaluadoresPorProyectoAsync(int idProyecto);

        Task<List<ProyectoJuradoCompleto>> ObtenerProyectosPorJuradoAsync(string documento);

    }
}
