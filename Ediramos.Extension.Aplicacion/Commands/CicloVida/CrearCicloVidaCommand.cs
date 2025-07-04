using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.CicloVida;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.CicloVida
{
    public class CrearCicloVidaCommand : IRequest<int>
    {
        public CrearCicloVidaDTo DTO { get; }
        public CrearCicloVidaCommand(CrearCicloVidaDTo dto)
        {
            DTO = dto;
        }

    }
}
