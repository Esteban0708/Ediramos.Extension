using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.PoblacionGrupo;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.PoblacionGrupo
{
    public class CrearPoblacionGrupoCommand : IRequest<int>
    {
        public CrearPoblacionGrupoDto DTO { get; }
        public CrearPoblacionGrupoCommand(CrearPoblacionGrupoDto dto)
        {
            DTO = dto;
        }
    }
}
