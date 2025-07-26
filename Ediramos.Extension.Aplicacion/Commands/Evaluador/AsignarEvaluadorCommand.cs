using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Evaluador;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Evaluador
{
    public class AsignarEvaluadorCommand : IRequest<bool>
    {
        public AsignarEvaluadorDTo Evaluador { get; set; }
        public AsignarEvaluadorCommand(AsignarEvaluadorDTo evaluador)
        {
            Evaluador = evaluador;
        }
    }
}
