using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.InscripcionGrupo;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{
    public class ObtenerSemestreQuery : IRequest<List<ObtenerSemestreDTo>>
    {
        public string Documento { get; set; }
        public ObtenerSemestreQuery(string documento)
        {
            Documento = documento;
        }
    }
}
