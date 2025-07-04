using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.CicloVida;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.CicloVida
{
    public class EditarCicloVidaCommand : IRequest<int>
    {
        public EditarCicloVidaDTo DTO { get; }
        public EditarCicloVidaCommand(EditarCicloVidaDTo dto)
        {
            DTO = dto;
        }
    }
}
