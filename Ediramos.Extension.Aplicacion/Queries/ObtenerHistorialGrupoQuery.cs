using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.InscripcionGrupo;
using Ediramos.Extension.Dominio.Entidades;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{
    public class ObtenerHistorialGrupoQuery : IRequest<List<ObtenerInscripcionGrupoDTo>>
    {
        public string Documento { get; set; }

        public ObtenerHistorialGrupoQuery(string documento)
        {
            Documento = documento;
        }
    }
}
