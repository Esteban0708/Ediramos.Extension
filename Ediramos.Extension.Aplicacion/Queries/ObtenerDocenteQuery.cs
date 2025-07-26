using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Usuario;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{
    public class ObtenerDocenteQuery : IRequest<List<ConsultarDocenteDTo>>
    {
        public string Filtro { get; }

        public ObtenerDocenteQuery(string filtro)
        {
            Filtro = filtro;
        }
    }

}
