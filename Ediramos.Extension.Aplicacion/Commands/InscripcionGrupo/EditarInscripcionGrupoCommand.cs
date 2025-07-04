using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Grupo;
using Ediramos.Extension.Aplicacion.DTOs.InscripcionGrupo;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.InscripcionGrupo
{
    public class EditarInscripcionGrupoCommand : IRequest<bool>
    {
        public int IdGrupo { get; set; }
        public CrearGrupoDTo Grupo { get; set; }

        public EditarInscripcionGrupoCommand(int idGrupo, CrearGrupoDTo grupo)
        {
            IdGrupo = idGrupo;
            Grupo = grupo;
        }
    }

}
