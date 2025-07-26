using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Grupo
{
    public class EliminarGrupoCommand : IRequest<int>
    {
        public int IdGrupo { get; set; }
        public EliminarGrupoCommand(int idGrupo)
        {
            IdGrupo = idGrupo;  
        }
    }
}
