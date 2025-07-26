using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Dapper;
using Ediramos.Extension.Aplicacion.DTOs.InscripcionGrupo;
using Ediramos.Extension.Dominio.Entidades;
using Ediramos.Extension.Dominio.Repositorios;
using Ediramos.Extension.Infraestructura.Persistencia;
using Microsoft.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;

namespace Ediramos.Extension.Infraestructura.Repositorios
{
    public class InscripcionGrupoRepository : IInscripcionGrupoRepository
    {
        private readonly DbConnectionFactory _connectionString;

        public InscripcionGrupoRepository(DbConnectionFactory connectioString)
        {
            _connectionString = connectioString;
        }

        public async Task<int> CrearGrupoAsync(string titulo, int? idAreaTrabajo)
        {
            using var conection = _connectionString.CreateSqlServerConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@Titulo", titulo);
            parametros.Add("@FK_IdAreaTrabajo", idAreaTrabajo);
            parametros.Add("@NuevoIdGrupo", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await conection.ExecuteAsync("CREARINSCRIPCIONGRUPO", parametros, commandType: CommandType.StoredProcedure);
            return parametros.Get<int>("@NuevoIdGrupo");
        }

        public async Task AgregarIntegranteAsync(int idGrupo, int pegeId, string documento, string nombreCompleto, bool esLider, string tipoVinculacion)
        {
            using var conection = _connectionString.CreateSqlServerConnection();

            var parametros = new
            {
                IdGrupo = idGrupo,
                PEGE_ID = pegeId,
                DocumentoIdentidad = documento,
                NombreCompleto = nombreCompleto,
                EsLider = esLider,
                TipoVinculacion = tipoVinculacion

            };

            await conection.ExecuteAsync("AGREGARINTEGRANTEGRUPO", parametros, commandType: CommandType.StoredProcedure);
        }


        public async Task AgregarObjetivoAsync(int idGrupo, string descripcion)
        {
            using var conection = _connectionString.CreateSqlServerConnection();

            var parametros = new
            {
                IdGrupo = idGrupo,
                Descripcion = descripcion
            };

            await conection.ExecuteAsync("AGREGAROBJETIVOGRUPO", parametros, commandType: CommandType.StoredProcedure);
        }
        public async Task<(List<ConsultarGrupo>, List<ConsultarInterno>, List<ConsultarExterno>)> ObtenerInscripcionGrupoAsync(bool incluirTodos)
        {
            using var connection = _connectionString.CreateSqlServerConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@IncluirTodos", incluirTodos);

            using var multi = await connection.QueryMultipleAsync(
                "OBTENERINSCRIPCIONGRUPO",
                parametros,
                commandType: CommandType.StoredProcedure
            );

            var grupos = (await multi.ReadAsync<ConsultarGrupo>()).ToList();
            var internos = (await multi.ReadAsync<ConsultarInterno>()).ToList();
            var externos = (await multi.ReadAsync<ConsultarExterno>()).ToList();

            return (grupos, internos, externos);
        }

        public async Task<List<ObjetivoGrupo>> ObtenerObjetivosGrupoAsync(int idGrupo)
        {
            using var connection = _connectionString.CreateSqlServerConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@IdGrupo", idGrupo);

            var objetivos = await connection.QueryAsync<ObjetivoGrupo>(
                "OBTENEROBJETIVOSGRUPO",
                parametros,
                commandType: CommandType.StoredProcedure
            );

            return objetivos.ToList();
        }
        public async Task<bool> ActualizarEstadoGrupoAsync(ActualizarEstadoGrupoIncri estadoIncri)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parametros = new DynamicParameters();

            parametros.Add("@IdGrupo", estadoIncri.IdGrupo);
            parametros.Add("@Estado", estadoIncri.Estado);
            parametros.Add("@Observacion", estadoIncri.Observacion);

            var filasAfectadas = await connection.ExecuteAsync(
                "ActualizarEstadoGrupoInscri",
                parametros,
                commandType: CommandType.StoredProcedure
            );

            return filasAfectadas > 0;
        }

        public async Task<int?> ObtenerPegeIdPorDocumentoAsync(string documento)
        {
            using var connection = _connectionString.CreateOracleConnection();
            await connection.OpenAsync();

            using var command = new OracleCommand("CONSULTARPEGE_ID", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add("p_documento", OracleDbType.Varchar2, 50).Value = documento;
            command.Parameters.Add("p_resultado", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return Convert.ToInt32(reader["PEGE_ID"]);
            }

            return null;
        }
        public async Task<List<HistorialGrupo>> ObtenerHistorialGrupoConIntegrantesAsync(string documento)
        {
            using var connection = _connectionString.CreateSqlServerConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@Documento", documento);

            using var multi = await connection.QueryMultipleAsync(
                "OBTENERHISTORIALGRUPO",
                parametros,
                commandType: CommandType.StoredProcedure
            );

            var historialList = (await multi.ReadAsync<HistorialGrupo>()).ToList();
            var internosList = (await multi.ReadAsync<ConsultarInterno>()).ToList();
            var externosList = (await multi.ReadAsync<ConsultarExterno>()).ToList();

            foreach (var grupo in historialList)
            {
                grupo.Internos = internosList.Where(i => i.IdGrupo == grupo.IdGrupo).ToList();
                grupo.Externos = externosList.Where(e => e.IdGrupo == grupo.IdGrupo).ToList();
            }

            return historialList;
        }
        public async Task EditarInscripcionGrupoAsync(
          int idGrupo,
          string nuevoTitulo,
          int? idAreaTrabajo,
          string jsonIntegrantes,
          string jsonObjetivos,
          string estado
          )
        {
            using var connection = _connectionString.CreateSqlServerConnection();

            var integrantes = JsonSerializer.Deserialize<List<IntegranteDTo>>(jsonIntegrantes);
            var objetivos = JsonSerializer.Deserialize<List<ObjetivoGrupo>>(jsonObjetivos);

            var tablaIntegrantes = new DataTable();
            tablaIntegrantes.Columns.Add("PEGE_ID", typeof(int));
            tablaIntegrantes.Columns.Add("DocumentoIdentidad", typeof(string));
            tablaIntegrantes.Columns.Add("NombreCompleto", typeof(string));
            tablaIntegrantes.Columns.Add("EsLider", typeof(bool));

            foreach (var integrante in integrantes)
            {
                tablaIntegrantes.Rows.Add(
                    integrante.Pege_id,
                    integrante.Documento,
                    integrante.NombreCompleto,
                    integrante.EsLider
                );
            }

            var tablaObjetivos = new DataTable();
            tablaObjetivos.Columns.Add("Descripcion", typeof(string));

            foreach (var objetivo in objetivos)
            {
                tablaObjetivos.Rows.Add(objetivo.Descripcion);
            }

            var parametros = new DynamicParameters();
            parametros.Add("@IdGrupo", idGrupo);
            parametros.Add("@NuevoTitulo", nuevoTitulo);
            parametros.Add("@FK_IdAreaTrabajo", idAreaTrabajo);
            parametros.Add("@Integrantes", tablaIntegrantes.AsTableValuedParameter("dbo.TipoIntegranteGrupo"));
            parametros.Add("@Objetivos", tablaObjetivos.AsTableValuedParameter("dbo.TipoObjetivoGrupo"));
            parametros.Add("@Estado", estado);

            await connection.ExecuteAsync(
                "EDITARINSCRIPCIONGRUPO",
                parametros,
                commandType: CommandType.StoredProcedure
            );
        }


    }
}
