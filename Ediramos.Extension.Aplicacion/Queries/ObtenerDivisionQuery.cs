using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Division;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{
    public class ObtenerDivisionQuery : IRequest<List<ObtenerDivisionDTO>>
    {
        public ObtenerDivisionQuery(){}

}
}
