using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Objetivo;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Objetivo
{
    public class EditarObjetivoCommand : IRequest<int>
    {
        public EditarObjetivoDto DTO { get; }

        public EditarObjetivoCommand(EditarObjetivoDto dto)
        {
            DTO = dto;
        }
    }
}
