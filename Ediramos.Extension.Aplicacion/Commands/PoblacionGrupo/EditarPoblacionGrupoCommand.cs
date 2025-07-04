using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.PoblacionGrupo;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.PoblacionGrupo
{
    public class EditarPoblacionGrupoCommand : IRequest<int>
    {
        public EditarPoblacionGrupoDTo DTO { get; }
        public EditarPoblacionGrupoCommand(EditarPoblacionGrupoDTo dto)
        {
            DTO = dto;
        }
    }
}
