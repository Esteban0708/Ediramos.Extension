using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.InscripcionGrupo;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.InscripcionGrupo
{
    public class ActualizarEstadoGrupoInscriCommand : IRequest<bool>
    {
        public ActualizarEstadoGrupoInscriDto Datos { get; set; }

        public ActualizarEstadoGrupoInscriCommand(ActualizarEstadoGrupoInscriDto datos)
        {
            Datos = datos;
        }
    }
}
