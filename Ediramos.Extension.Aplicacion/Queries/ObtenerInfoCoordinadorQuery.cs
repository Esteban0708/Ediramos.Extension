using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.InscripcionGrupo;
using Ediramos.Extension.Aplicacion.DTOs.RolPermisos;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{
    public class ObtenerInfoCoordinadorQuery : IRequest<List<ObtenerInfoCoordinaDTo>>
    {
        public string Documento { get; set; }

        public ObtenerInfoCoordinadorQuery(string documento)
        {
            Documento = documento;
        }
    }


}
