using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Indicadores_Proyecto;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{
    public class ObtenerIndicadoresProyectoQuery : IRequest<IndicadoresProyectoDTo>
    {
        public int IdProyecto { get; set; }

        public ObtenerIndicadoresProyectoQuery(int idProyecto)
        {
            IdProyecto = idProyecto;
        }
    }
}
