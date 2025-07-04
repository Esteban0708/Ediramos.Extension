using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Grupo;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Grupo
{
    public class CrearGrupoCommand : IRequest<int>
    {
        public CrearGrupoDTO DTO { get; }
        public CrearGrupoCommand(CrearGrupoDTO dto)
        {
            DTO = dto;
        }
    }
}
