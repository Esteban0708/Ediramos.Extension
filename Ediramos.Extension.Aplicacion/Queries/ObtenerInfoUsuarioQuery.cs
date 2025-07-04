using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Usuario;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{
    public class ObtenerInfoUsuarioQuery : IRequest<List<ObtenerInforUsuarioDTo>>
    {
        public string Documento { get; set; }

        public ObtenerInfoUsuarioQuery(string documento)
        {
            Documento = documento;
        }
    }
}
