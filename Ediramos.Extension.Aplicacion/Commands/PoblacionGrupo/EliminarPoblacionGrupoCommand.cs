using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.PoblacionGrupo
{
    public class EliminarPoblacionGrupoCommand : IRequest<int>
    {
        public int IdGrupo { get; }
        public EliminarPoblacionGrupoCommand(int idGrupo)
        {
            IdGrupo = idGrupo;
        }
    }
}
