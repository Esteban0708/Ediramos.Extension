using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Proyecto;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Proyecto
{
    public class CrearProyectoCommand : IRequest<int>
    {
        public ProyectoCompletoDTO Proyecto { get; set; }
        public CrearProyectoCommand( ProyectoCompletoDTO proyecto)
        {
            Proyecto = proyecto;
        }
    }
}
