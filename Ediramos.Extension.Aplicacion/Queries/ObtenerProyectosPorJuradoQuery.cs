using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Evaluador;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{
    public class ObtenerProyectosPorJuradoQuery : IRequest<List<ProyectoJuradoCompletoDTo>>
    {
        public string Documento { get; set; }
        public ObtenerProyectosPorJuradoQuery(string documento)
        {
            Documento = documento;
        }
    }
}
