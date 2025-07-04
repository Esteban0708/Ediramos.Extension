using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Grupo;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{
    public class ObtenerGrupoQuery : IRequest<List<ObtenerGrupoDTO>>
    {
        public ObtenerGrupoQuery()
        {
        }
    }
}
