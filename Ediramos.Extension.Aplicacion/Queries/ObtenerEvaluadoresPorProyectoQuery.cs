using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Evaluador;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{
    public class ObtenerEvaluadoresPorProyectoQuery : IRequest<List<ObtenerEvaluadorDTo>>
    {
        public int IdProyecto { get; set; }

        public ObtenerEvaluadoresPorProyectoQuery(int idProyecto)
        {
            IdProyecto = idProyecto;
        }
    }

}
