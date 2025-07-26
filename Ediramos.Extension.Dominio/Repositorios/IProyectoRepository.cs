using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Indicadores_Proyecto;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Aplicacion.Handlers.Proyecto
{
    public interface IProyectoRepository
    {
        Task<int> CrearProyectoAsync(ProyectoCompleto model);
        Task AsignarGrupoProyectoAsync(int idProyecto, int idGrupo);
        Task InsertarCoberturaAsync(int idProyecto, string tipo, List<int> ids);
        Task InsertarCronogramaAsync(int idProyecto, List<ObjetivoEspecifico> objetivos);
        Task<int> CrearPresupuestoAsync(int idProyecto, float total);
        Task InsertarProductosAsync(int idPresupuesto, List<ProductoPresupuesto> productos);
        Task InsertarFuentesAsync(int idPresupuesto, List<FuenteFinanciacion> fuentes);
        Task InsertarParticipantesInternosAsync(int idGrupo, int idProyecto);
        Task InsertarParticipantesExternosAsync(int idGrupo, int idProyecto);
        Task<DetalleProyectosUsuario> ObtenerProyectosUsuarioAsync(string documentoIdentidad);

        Task<IndicadoresProyecto> ObtenerIndicadoresAsync(int idProyecto);
        Task<CronogramaPresupuesto> ObtenerCronogramaPresupuestoAsync(int idProyecto);


    }
}
