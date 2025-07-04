using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Usuario;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{ 
    public class ObtenerCorreosQuery : IRequest<List<CorreoUsuarioDTo>>
    {
        public List<int> PegeIds { get; }
        public List<string> Documentos { get; }

        public ObtenerCorreosQuery(List<int> pegeIds, List<string> documentos)
        {
            PegeIds = pegeIds;
            Documentos = documentos;
        }
    }

}
