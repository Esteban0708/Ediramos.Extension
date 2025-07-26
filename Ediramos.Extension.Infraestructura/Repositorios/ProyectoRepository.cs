using System;
using System.Data;
using Dapper;
using Ediramos.Extension.Aplicacion.DTOs.Cronograma_Proyecto;
using Ediramos.Extension.Aplicacion.DTOs.Indicadores_Proyecto;
using Ediramos.Extension.Aplicacion.DTOs.Proyecto;
using Ediramos.Extension.Aplicacion.Handlers.Proyecto;
using Ediramos.Extension.Dominio.Entidades;
using Ediramos.Extension.Infraestructura.Persistencia;
using FuenteFinanciacionDTo = Ediramos.Extension.Aplicacion.DTOs.Cronograma_Proyecto.FuenteFinanciacionDTo;

namespace Ediramos.Extension.Infraestructura.Repositorios
{
    public class ProyectoRepository : IProyectoRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public ProyectoRepository(DbConnectionFactory connectionFactory) { 
        
            _connectionFactory = connectionFactory;
        }
        public async Task<int> CrearProyectoAsync(ProyectoCompleto model)
        {
            using var connection = _connectionFactory.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@NombreProyecto", model.NombreProyecto);
            parameters.Add("@FechaInicio", model.FechaInicio);
            parameters.Add("@FechaFin", model.FechaFin);
            parameters.Add("@Duracion", model.Duracion);
            parameters.Add("@ObjetivoGeneral", model.ObjetivoGeneral);
            parameters.Add("@PlanteamientoProblema", model.PlanteamientoProblema);
            parameters.Add("@Metodologia", model.Metodologia);
            parameters.Add("@Justificacion", model.Justificacion);
            parameters.Add("@ComponenteInnovador", model.ComponenteInnovador);
            parameters.Add("@PoblacionDirigida", model.PoblacionDirigida);
            parameters.Add("@ResultadoAcciones3_1", model.ResultadoAcciones);
            parameters.Add("@Estado", model.Estado);
            parameters.Add("@FK_IdConvocatoria", model.IdConvocatoria);

            await connection.ExecuteAsync("CREARPROYECTO", parameters, commandType: CommandType.StoredProcedure);

            return await connection.QuerySingleAsync<int>("SELECT MAX(IdProyecto) FROM PROYECTO");
        }

        public async Task AsignarGrupoProyectoAsync(int idProyecto, int idGrupo)
        {
            using var connection = _connectionFactory.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@FK_IdProyecto", idProyecto);
            parameters.Add("@FK_IdGrupo", idGrupo);
            await connection.ExecuteAsync("ASIGNARGRUPOPROYECTO", parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task InsertarCoberturaAsync(int idProyecto, string tipo, List<int> ids)
        {
            using var connection = _connectionFactory.CreateSqlServerConnection();

            foreach (var id in ids)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FK_IdProyecto", idProyecto);

                switch (tipo.ToLower())
                {
                    case "area":
                        parameters.Add("@FK_IdAreaTrabajo", id);
                        await connection.ExecuteAsync("INSERTARPROYECTOAREA", parameters, commandType: CommandType.StoredProcedure);
                        break;

                    case "ciclo":
                        parameters.Add("@FK_IdCicloVital", id);
                        await connection.ExecuteAsync("INSERTARPROYECTOCICLO", parameters, commandType: CommandType.StoredProcedure);
                        break;

                    case "condicion":
                        parameters.Add("@FK_IdPoblacion", id);
                        await connection.ExecuteAsync("INSERTARPROYECTOCONDICION", parameters, commandType: CommandType.StoredProcedure);
                        break;

                    case "grupo":
                        parameters.Add("@FK_IdGrupoPoblacional", id);
                        await connection.ExecuteAsync("INSERTARPROYECTOGRUPOPOBLACIONAL", parameters, commandType: CommandType.StoredProcedure);
                        break;

                    default:
                        throw new ArgumentException($"Tipo de cobertura no reconocido: {tipo}");
                }
            }
        }

        public async Task InsertarCronogramaAsync(int idProyecto, List<ObjetivoEspecifico> objetivos)
        {
            using var connection = _connectionFactory.CreateSqlServerConnection();

            foreach (var objetivo in objetivos)
            {
                var paramObj = new DynamicParameters();
                paramObj.Add("@Descripcion", objetivo.Descripcion);
                paramObj.Add("@Estado", true);
                paramObj.Add("@FK_IdProyecto", idProyecto);
                await connection.ExecuteAsync("INSERTAROBJETIVOESPECIFICO", paramObj, commandType: CommandType.StoredProcedure);
                int idObjetivo = await connection.QuerySingleAsync<int>("SELECT MAX(IdObjetivoEspecifico) FROM OBJETIVOESPECIFICO");

                foreach (var meta in objetivo.Metas)
                {
                    var paramMeta = new DynamicParameters();
                    paramMeta.Add("@Descripcion", meta.Descripcion);
                    paramMeta.Add("@Estado", true);
                    paramMeta.Add("@FK_IdObjetivo", idObjetivo);
                    await connection.ExecuteAsync("INSERTARMETA", paramMeta, commandType: CommandType.StoredProcedure);
                    int idMeta = await connection.QuerySingleAsync<int>("SELECT MAX(IdMeta) FROM META");

                    foreach (var actividad in meta.Actividades)
                    {
                        var paramAct = new DynamicParameters();
                        paramAct.Add("@Descripcion", actividad.Descripcion);
                        paramAct.Add("@Estado", true);
                        paramAct.Add("@FK_IdMeta", idMeta);
                        await connection.ExecuteAsync("INSERTARACTIVIDAD", paramAct, commandType: CommandType.StoredProcedure);
                        int idActividad = await connection.QuerySingleAsync<int>("SELECT MAX(IdActividad) FROM ACTIVIDAD");

                        foreach (var idPeriodo in actividad.Periodos)
                        {
                            var paramPer = new DynamicParameters();
                            paramPer.Add("@FK_IdActividad", idActividad);
                            paramPer.Add("@FK_IdPeriodo", idPeriodo);
                            paramPer.Add("@Estado", true);
                            await connection.ExecuteAsync("INSERTARACTIVIDADPERIODO", paramPer, commandType: CommandType.StoredProcedure);
                        }
                    }
                }
            }
        }
        public async Task<int> CrearPresupuestoAsync(int idProyecto, float total)
        {
            using var connection = _connectionFactory.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Total", total);
            parameters.Add("@Estado", true);
            parameters.Add("@FK_IdProyecto", idProyecto);
            await connection.ExecuteAsync("CREARPRESUPUESTO", parameters, commandType: CommandType.StoredProcedure);
            return await connection.QuerySingleAsync<int>("SELECT MAX(IdPresupuesto) FROM PRESUPUESTO");
        }
        public async Task InsertarProductosAsync(int idPresupuesto, List<ProductoPresupuesto> productos)
        {
            using var connection = _connectionFactory.CreateSqlServerConnection();

            foreach (var p in productos)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FK_IdProducto", p.IdProducto);
                parameters.Add("@FK_IdPresupuesto", idPresupuesto);
                parameters.Add("@Cantidad", p.Cantidad);
                parameters.Add("@ValorUnitario", p.ValorUnitario);
                parameters.Add("@FK_UnidadMedida", p.IdUnidadMedida);
                await connection.ExecuteAsync("INSERTARPRODUCTOPRESUPUESTO", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task InsertarFuentesAsync(int idPresupuesto, List<FuenteFinanciacion> fuentes)
        {
            using var connection = _connectionFactory.CreateSqlServerConnection();

            foreach (var f in fuentes)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Entidad", f.Entidad);
                parameters.Add("@Valor", f.Valor);
                parameters.Add("@Estado", f.Estado);
                parameters.Add("@FK_IdPresupuesto", idPresupuesto);
                await connection.ExecuteAsync("INSERTARFUENTEFINANCIAMIENTO", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task InsertarParticipantesInternosAsync(int idGrupo, int idProyecto)
        {
            using var connection = _connectionFactory.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdGrupo", idGrupo);
            parameters.Add("@IdProyecto", idProyecto);
            await connection.ExecuteAsync("INSERTAR_PARTICIPANTES_INTERNOS", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task InsertarParticipantesExternosAsync(int idGrupo, int idProyecto)
        {
            using var connection = _connectionFactory.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdGrupo", idGrupo);
            parameters.Add("@IdProyecto", idProyecto);
            await connection.ExecuteAsync("INSERTAR_PARTICIPANTES_EXTERNOS", parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<DetalleProyectosUsuario> ObtenerProyectosUsuarioAsync(string documentoIdentidad)
        {
            using var connection = _connectionFactory.CreateSqlServerConnection();
            using var multi = await connection.QueryMultipleAsync(
                "OBTENER_PROYECTOSUSUARIO",
            new { Documento = documentoIdentidad },
                commandType: CommandType.StoredProcedure
            );

            var proyectos = (await multi.ReadAsync<ProyectoUsuario>()).ToList();
            var internos = (await multi.ReadAsync<ParticipanteInterno>()).ToList();
            var externos = (await multi.ReadAsync<ParticipanteExterno>()).ToList();
            var seguimientos = (await multi.ReadAsync<SeguimientoProyecto>()).ToList();

            return new DetalleProyectosUsuario
            {
                Proyectos = proyectos,
                ParticipantesInternos = internos,
                ParticipantesExternos = externos,
                Seguimientos = seguimientos
            };
        }
        public async Task<IndicadoresProyecto> ObtenerIndicadoresAsync(int idProyecto)
        {
            using var connection = _connectionFactory.CreateSqlServerConnection();

            using var multi = await connection.QueryMultipleAsync(
                "OBTENER_INDICADORESPROYECTO",
                new { IdProyecto = idProyecto },
                commandType: CommandType.StoredProcedure
            );

            var result = new IndicadoresProyecto
            {
                ObjetivosEspecificos = multi.Read<ObjetivoEspecificoProyecto>().ToList(),
                AreasTrabajo = multi.Read<AreaTrabajo>().ToList(),
                CiclosVida = multi.Read<CicloVida>().ToList(),
                PoblacionesCondicion = multi.Read<PoblacionCondicion>().ToList(),
                GruposProyecto = multi.Read<GrupoProyecto>().ToList()
            };

            return result;
        }
        public async Task<CronogramaPresupuesto> ObtenerCronogramaPresupuestoAsync(int idProyecto)
        {
            using var connection = _connectionFactory.CreateSqlServerConnection();
            using var multi = await connection.QueryMultipleAsync(
                "OBTENERCRONOGRAMAPRESUPUESTO",
            new { IdProyecto = idProyecto },
                commandType: CommandType.StoredProcedure);

            var cronograma = (await multi.ReadAsync<Cronograma>()).ToList();
            var presupuestoProductos = (await multi.ReadAsync<PresupuestoProducto>()).ToList();
            var fuentes = (await multi.ReadAsync<FuenteFinanciacion>()).ToList();

            return new CronogramaPresupuesto
            {
                Cronograma = cronograma,
                PresupuestoProductos = presupuestoProductos,
                FuentesFinanciacion = fuentes
            };
        }
    }
}
