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
    public class AreaTrabajoRepository : IAreaTrabajoRepository
    {
        public readonly DbConnectionFactory _connectionString;
        public AreaTrabajoRepository(DbConnectionFactory connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<int> CrearAreaTrabajoAsync(string nombre)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", nombre);
            await connection.ExecuteAsync("CREARAREATRABAJO", parameters, commandType: CommandType.StoredProcedure);
            return 1;
        }
        public async Task<List<AreaTrabajo>> ObtenerAreasTrabajoAsync()
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var areaTrabajo = await connection.QueryAsync<AreaTrabajo>("OBTENERAREATRABAJO");
            return areaTrabajo.ToList();
        }
        public async Task<int> EditarAreaTrabajoAsync(int id, string nombre)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdAreaTrabajo", id);
            parameters.Add("@Nombre", nombre);
            await connection.ExecuteAsync("EDITARAREATRABAJO", parameters, commandType: CommandType.StoredProcedure);
            return 1;
        }
        public async Task<int> EliminarAreaTrabajoAsync(int id)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdAreaTrabajo", id);
            await connection.ExecuteAsync("ELIMINARAREATRABAJO", parameters, commandType: CommandType.StoredProcedure);
            return 1;
        }
    }
}
