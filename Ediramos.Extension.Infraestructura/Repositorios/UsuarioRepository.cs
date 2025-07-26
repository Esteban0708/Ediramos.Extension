using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Ediramos.Extension.Aplicacion.DTOs.Permisos;
using Ediramos.Extension.Aplicacion.DTOs.RolPermisos;
using Ediramos.Extension.Aplicacion.DTOs.Sesion;
using Ediramos.Extension.Aplicacion.DTOs.Usuario;
using Ediramos.Extension.Dominio.Entidades;
using Ediramos.Extension.Dominio.Repositorios;
using Ediramos.Extension.Infraestructura.Persistencia;
using Microsoft.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;

namespace Ediramos.Extension.Infraestructura.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbConnectionFactory _connectionString;
        public UsuarioRepository(DbConnectionFactory configuration)
        {
            _connectionString = configuration;
        }
        public async Task<Usuario> LoginAsycn(string correo, string contrasena)
        {
            using var connection = _connectionString.CreateOracleConnection();
            await connection.OpenAsync();

            var parameters = new DynamicParameters();
            parameters.Add("p_correo", correo);
            parameters.Add("p_contrasena", contrasena);
            parameters.Add("p_pege_id", dbType: DbType.Int32);
            parameters.Add("p_nombre_completo", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
            parameters.Add("p_correo_out", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameters.Add("p_documento", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
            parameters.Add("p_telefono", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);

            await connection.ExecuteAsync("DES_EDRAMOS.OBTENERDATOSPERSONA", parameters, commandType: CommandType.StoredProcedure);

            var documento = parameters.Get<string>("p_documento");

            using var command = new OracleCommand("CONSULTAR_ESTADO_PERSONA", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("p_documento", OracleDbType.Varchar2, 50).Value = documento;
            command.Parameters.Add("p_resultado", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            using var reader = await command.ExecuteReaderAsync();

            var Estatus = new List<EstadoPersona>();
            while (await reader.ReadAsync())
            {
                Estatus.Add(new EstadoPersona
                {
                    Estatus = reader.GetString(0)
                });
            }

            return new Usuario
            {
                Pege_id = parameters.Get<int>("p_pege_id"),
                Nombre = parameters.Get<string>("p_nombre_completo"),
                Correo = parameters.Get<string>("p_correo_out"),
                Documento = documento,
                Telefono = parameters.Get<string>("p_telefono"),
                Estatus = Estatus
            };

        }
        public async Task RegistrarUsuarioAsync(Usuario usuario)
        {
            using var connection = _connectionString.CreateSqlServerConnection();

            var rolesTable = new DataTable();
            rolesTable.Columns.Add("Nombre", typeof(string));

            foreach (var rol in usuario.Estatus)
            {
                rolesTable.Rows.Add(rol.Estatus);
            }

            var parameters = new DynamicParameters();
            parameters.Add("@PEGE_ID", usuario.Pege_id);
            parameters.Add("@NombreCompleto", usuario.Nombre);
            parameters.Add("@DocumentoIdentidad", usuario.Documento);
            parameters.Add("@Roles", rolesTable.AsTableValuedParameter("dbo.RolesTabla"));

            await connection.ExecuteAsync("REGISTRARUSUARIO_MULTI", parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task AsignarRolUsuarioAsync(int pegeId, string nombreCompleto, string documentoIdentidad, int idRol)
        {
            using var connection = _connectionString.CreateSqlServerConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@PEGE_ID", pegeId);
            parameters.Add("@NombreCompleto", nombreCompleto);
            parameters.Add("@DocumentoIdentidad", documentoIdentidad);
            parameters.Add("@IdRol", idRol);

            await connection.ExecuteAsync("ASIGNARROL", parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<Rol>> ObtenerRolesDeUsuarioAsync(int pegeId)
        {
            using var connection = _connectionString.CreateSqlServerConnection();

            var query = "EXEC OBTENERROLESUSUARIO @PEGE_ID";

            var result = await connection.QueryAsync<Rol>(
                query,
                new { PEGE_ID = pegeId }
            );

            return result;
        }
        public async Task<List<InforUsuario>> ObtenerInfoUsuarioAsync(string documento)
        {
            using var connection = _connectionString.CreateOracleConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = "DES_EDRAMOS.CONSULTARINFORINTEGRA_MULTI";
            command.CommandType = CommandType.StoredProcedure;

            var param1 = command.CreateParameter();
            param1.ParameterName = "p_documento";
            param1.DbType = DbType.String;
            param1.Direction = ParameterDirection.Input;
            param1.Value = documento;
            command.Parameters.Add(param1);

            var param2 = command.CreateParameter();
            param2.ParameterName = "p_resultado";
            ((OracleParameter)param2).OracleDbType = OracleDbType.RefCursor;
            param2.Direction = ParameterDirection.Output;
            command.Parameters.Add(param2);

            var resultado = new List<InforUsuario>();
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                resultado.Add(new InforUsuario
                {
                    Pege_id = reader["PEGE_ID"] != DBNull.Value ? Convert.ToInt32(reader["PEGE_ID"]) : 0,
                    Documento = reader["DOCUMENTO"]?.ToString(),
                    Nombres = reader["NOMBRES"]?.ToString(),
                    Apellidos = reader["APELLIDOS"]?.ToString(),
                    Dependencia = reader["DEPENDENCIA"]?.ToString(),
                    Programa = reader["PROGRAMA"]?.ToString(),
                    Eps = reader["EPS"]?.ToString(),
                    Estatus = reader["ESTATUS"]?.ToString()
                });
            }

            return resultado;
        }
        public async Task<List<CorreoUsuario>> ObtenerCorreosPorPegeIdsYDocumentosAsync(
           List<int> pegeIds, List<string> documentos)
        {
            var correos = new List<CorreoUsuario>();

            var idsValidos = pegeIds?.Where(id => id > 0).ToList();

            if (idsValidos != null && idsValidos.Any())
            {
                using var oracle = _connectionString.CreateOracleConnection();
                await oracle.OpenAsync();

                foreach (var pegeId in idsValidos)
                {
                    using var cmd = oracle.CreateCommand();
                    cmd.CommandText = "DES_EDRAMOS.OBTENERCORREO";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Clear();

                    var pId = new OracleParameter("p_pege_id", OracleDbType.Int32)
                    {
                        Direction = ParameterDirection.Input,
                        Value = pegeId
                    };
                    var pCorreo = new OracleParameter("p_correo", OracleDbType.Varchar2, 200)
                    {
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(pId);
                    cmd.Parameters.Add(pCorreo);

                    try
                    {
                        await cmd.ExecuteNonQueryAsync();

                        var correo = pCorreo.Value?.ToString();
                        if (!string.IsNullOrWhiteSpace(correo))
                        {
                            correos.Add(new CorreoUsuario
                            {
                                Pege_id = pegeId,
                                Correo = correo
                            });
                        }
                    }
                    catch (OracleException ex)
                    {
                        if (ex.Number != 1403)
                            throw; 
                    }
                }
            }

            if (documentos != null && documentos.Any())
            {
                using var sql = _connectionString.CreateSqlServerConnection();

                foreach (var doc in documentos)
                {
                    if (long.TryParse(doc, out long documentoLong))
                    {
                        var correo = await sql.QueryFirstOrDefaultAsync<string>(
                            "OBTENERCORREOUE",
                            new { Documento = documentoLong },
                            commandType: CommandType.StoredProcedure
                        );

                        if (!string.IsNullOrWhiteSpace(correo))
                        {
                            correos.Add(new CorreoUsuario
                            {
                                Pege_id = 0,
                                Correo = correo
                            });
                        }
                    }

                }
            }

            return correos;
        }
        public async Task<List<ConsultarDocentes>> BuscarDocentesAsync(string filtro)
        {
            using var connection = _connectionString.CreateOracleConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = "DES_EDRAMOS.CONSULTARDOCENTE"; 
            command.CommandType = CommandType.StoredProcedure;

            var param1 = command.CreateParameter();
            param1.ParameterName = "p_documento";
            param1.DbType = DbType.String;
            param1.Value = filtro;
            param1.Direction = ParameterDirection.Input;
            command.Parameters.Add(param1);

            var param2 = command.CreateParameter();
            param2.ParameterName = "p_resultado";
            ((Oracle.ManagedDataAccess.Client.OracleParameter)param2).OracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.RefCursor;
            param2.Direction = ParameterDirection.Output;
            command.Parameters.Add(param2);

            var resultado = new List<ConsultarDocentes>();
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                resultado.Add(new ConsultarDocentes
                {
                    pege_id = reader["PEGE_ID"] != DBNull.Value ? Convert.ToInt32(reader["PEGE_ID"]) : 0,
                    documento = reader["DOCUMENTO"]?.ToString(),
                    nombreCompleto = reader["NOMBRE_COMPLETO"]?.ToString(),
                    programa = reader["PROGRAMA"]?.ToString(),
                    dependencia = reader["DEPENDENCIA"]?.ToString()
                });
            }

            return resultado;
        }


    }
}
