using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration.Conventions;
using Dapper;
using Ediramos.Extension.Dominio.Entidades;
using Ediramos.Extension.Dominio.Repositorios;
using Ediramos.Extension.Infraestructura.Persistencia;

namespace Ediramos.Extension.Infraestructura.Repositorios
{
    public class RolRepository : IRolRepository
    {
        private readonly DbConnectionFactory _connectionString;

        public RolRepository(DbConnectionFactory connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task CrearRolAsync(string nombre, string colorHex, List<int> permisos)
        {
            using var connection = _connectionString.CreateSqlServerConnection();

            var permisoTable = new DataTable();
            permisoTable.Columns.Add("IdPermiso", typeof(int));

            foreach (var permisoId in permisos) {

                permisoTable.Rows.Add(permisoId);

            }

            var parametrs = new DynamicParameters();
            parametrs.Add("@Nombre", nombre);
            parametrs.Add("@ColorHex", colorHex);
            parametrs.Add("@Permisos", permisoTable.AsTableValuedParameter("PermisoIdTableType"));

            await connection.ExecuteAsync("CrearRol", parametrs, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Rol>> ObtenerPermisoRolAsync()
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var permisoRol = await connection.QueryAsync<Rol>(
                "OBTENERPERMISOSROL",
                commandType: CommandType .StoredProcedure
                );
            return permisoRol.ToList();
        }
        public async Task<bool> ActualizarRolAsync(int idRol, string nombreRol, string colorHex, List<int> permisos)
        {
            using var connection = _connectionString.CreateSqlServerConnection();

            var permisoTable = new DataTable();
            permisoTable.Columns.Add("IdPermiso", typeof(int));

            foreach (var permisoId in permisos)
            {
                permisoTable.Rows.Add(permisoId);
            }

            var parameters = new DynamicParameters();
            parameters.Add("@IdRol", idRol);
            parameters.Add("@NombreRol", nombreRol);
            parameters.Add("@ColorHex", colorHex);
            parameters.Add("@Permisos", permisoTable.AsTableValuedParameter("PermisoIdTableType"));

            var result = await connection.ExecuteAsync("ACTUALIZARROL", parameters, commandType: CommandType.StoredProcedure);

            return true;
        }
        public async Task<int> EliminarRolAsync(int id)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdRol", id);
            await connection.ExecuteAsync("ELIMINARROL", parameters, commandType: CommandType.StoredProcedure);
            return 1;
        }
        public async Task<List<RolConteoUsuarios>> ContarUsuariosPorRolAsync()
        {
            using var connection = _connectionString.CreateSqlServerConnection();

            var resultado = await connection.QueryAsync<RolConteoUsuarios>(
                "CONTARUSUARIOROL",
                commandType: CommandType.StoredProcedure);

            return resultado.ToList();
        }
        public async Task<List<ObtenerUsuarioRol>> ObtenerUsuarioRolAsync(int IdRol)
        {
            using var connection = _connectionString.CreateSqlServerConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@IdRol", IdRol);

            var resultado = await connection.QueryAsync<ObtenerUsuarioRol>(
                "OBTENERUSUARIOSROL", 
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return resultado.ToList();
        }
        public async Task<bool> DesactivarUsuarioRolAsync(int pegeId, int idRol)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@PegeId", pegeId);
            parameters.Add("@IdRol", idRol);

            var result = await connection.ExecuteAsync("DESACTIVARUSUARIOROL", parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

    }
}
