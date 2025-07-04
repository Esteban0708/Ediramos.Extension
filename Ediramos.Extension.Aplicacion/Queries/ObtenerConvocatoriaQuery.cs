using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Convocatoria;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{
    public class ObtenerConvocatoriaQuery : IRequest<List<ObtenerConvocatoriaDTo>>
    {
        public ObtenerConvocatoriaQuery() { }
    }

}
