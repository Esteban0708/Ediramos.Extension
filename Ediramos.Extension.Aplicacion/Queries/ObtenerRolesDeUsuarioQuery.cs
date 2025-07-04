using Ediramos.Extension.Aplicacion.DTOs.RolPermisos;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{
    public class ObtenerRolesDeUsuarioQuery : IRequest<IEnumerable<ObtenerPermisosRolDTo>>
    {
        public int PegeId { get; set; }

        public ObtenerRolesDeUsuarioQuery(int pegeId)
        {
            PegeId = pegeId;
        }
    }
}
