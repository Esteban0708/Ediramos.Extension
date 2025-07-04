using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Objetivo;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{
    public class ObtenerObjetivosQuery : IRequest<List<ObtenerObjetivoDTO>>
    {
    }
}
