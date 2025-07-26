using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Proyecto;
using Ediramos.Extension.Dominio.Entidades;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{
    public class ObtenerProyectosUsuarioQuery : IRequest<DetalleProyectosUsuario>
    {
        public string DocumentoIdentidad { get; set; }

        public ObtenerProyectosUsuarioQuery(string documento)
        {
            DocumentoIdentidad = documento;
        }
    }
}
