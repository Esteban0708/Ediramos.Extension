using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.InscripcionGrupo;
using Ediramos.Extension.Aplicacion.DTOs.UsuarioExterno;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{
    public class ObtenerObjetivoGrupoQuery : IRequest<List<ObtenerObjetivoGrupoDTo>>
    {
        public string IdGrupo { get; set; }

        public ObtenerObjetivoGrupoQuery(string idGrupo)
        {
            IdGrupo = idGrupo;
        }
    }
}
