using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Dominio.Repositorios
{

   public interface IInscripcionGrupoRepository
   {
        Task<int> CrearGrupoAsync(string titulo, int? idAreaTrabajo);
        Task AgregarIntegranteAsync(int idGrupo, int pegeId, string documento, string nombreCompleto, bool esLider);
        Task AgregarObjetivoAsync(int idGrupo, string descripcion);
        Task<(List<ConsultarGrupo>, List<ConsultarInterno>, List<ConsultarExterno>)> ObtenerInscripcionGrupoAsync(bool incluirTodos);
        Task<List<ObjetivoGrupo>> ObtenerObjetivosGrupoAsync(int idGrupo);
        Task<bool> ActualizarEstadoGrupoAsync(ActualizarEstadoGrupoIncri estadoIncri);
        Task<int?> ObtenerPegeIdPorDocumentoAsync(string documento);
        Task<List<HistorialGrupo>> ObtenerHistorialGrupoConIntegrantesAsync(string documento);
        Task EditarInscripcionGrupoAsync(int idGrupo, string nuevoTitulo, int? idAreaTrabajo, 
            string jsonIntegrantes, string jsonObjetivos, string estado);

    }
}