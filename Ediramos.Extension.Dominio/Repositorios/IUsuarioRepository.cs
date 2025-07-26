using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Dominio.Repositorios
{
    public interface IUsuarioRepository
    {
        Task<Usuario> LoginAsycn(string correo, string contraseña);
        Task RegistrarUsuarioAsync(Usuario usuario);
        Task AsignarRolUsuarioAsync(int pegeId, string nombreCompleto, string documentoIdentidad, int idRol);
        Task<IEnumerable<Rol>> ObtenerRolesDeUsuarioAsync(int pegeId);

        Task<List<InforUsuario>> ObtenerInfoUsuarioAsync(string documento);
        Task<List<CorreoUsuario>> ObtenerCorreosPorPegeIdsYDocumentosAsync(List<int> pegeIds, List<string> documentos);
        Task<List<ConsultarDocentes>> BuscarDocentesAsync(string filtro);
    }
}
