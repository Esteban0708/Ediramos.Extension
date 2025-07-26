using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{
    public class ObtenerAnexosProyectoQuery : IRequest<ProyectoAnexo?>
    {
        public string IdProyecto { get; }

        public ObtenerAnexosProyectoQuery(string idProyecto)
        {
            IdProyecto = idProyecto;
        }
    }
}
