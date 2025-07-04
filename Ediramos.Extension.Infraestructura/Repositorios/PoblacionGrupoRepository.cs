using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Ediramos.Extension.Dominio.Entidades;
using Ediramos.Extension.Dominio.Repositorios;
using Ediramos.Extension.Infraestructura.Persistencia;

namespace Ediramos.Extension.Infraestructura.Repositorios
{
    public class PoblacionGrupoRepository : IPoblacionGrupoRepository
    {
        public readonly DbConnectionFactory _connectionString;
        public PoblacionGrupoRepository(DbConnectionFactory connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<int> CrearPoblacionGrupoAsync(string nombre)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", nombre);
            await connection.ExecuteAsync("CREARPOBLACIONGRUPO", parameters, commandType: CommandType.StoredProcedure);
            return 1;
        }
        public async Task<List<PoblacionGrupo>> ObtenerPoblacionesGruposAsync()
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var poblaciones = await connection.QueryAsync<PoblacionGrupo>("OBTENERPOBLACIONGRUPO");
            return poblaciones.ToList();
        }
        public async Task<int> EditarPoblacionGrupoAsync(int id, string nombre)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdGrupo", id);
            parameters.Add("@Nombre", nombre);
            await connection.ExecuteAsync("EDITARPOBLACIONGRUPO", parameters, commandType: CommandType.StoredProcedure);
            return 1;
        }
        public async Task<int> EliminarPoblacionGrupoAsync(int id)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdGrupo", id);
            await connection.ExecuteAsync("ELIMINARPOBLACIONGRUPO", parameters, commandType: CommandType.StoredProcedure);
            return 1;
        }
    }
}
