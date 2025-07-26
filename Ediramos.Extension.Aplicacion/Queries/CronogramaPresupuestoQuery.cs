using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Cronograma_Proyecto;
using Ediramos.Extension.Dominio.Entidades;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{
    public class CronogramaPresupuestoQuery : IRequest<CronogramaPresupuestoDTo>
    {
        public int IdProyecto { get; set; }

        public CronogramaPresupuestoQuery(int idProyecto)
        {
            IdProyecto = idProyecto;
        }
    }
}
