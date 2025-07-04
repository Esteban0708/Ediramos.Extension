using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.UsuarioExterno;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{
    public class ObtenerUsuarioExternoQuery : IRequest<List<ObtenerUsuarioExternoDTo>>
    {
        public string DocumentoParcial { get; set; }

        public ObtenerUsuarioExternoQuery(string documentoParcial)
        {
            DocumentoParcial = documentoParcial;
        }
    }

}
