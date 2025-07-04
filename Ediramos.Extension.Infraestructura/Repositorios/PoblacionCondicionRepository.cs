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
    public class PoblacionCondicionRepository : IPoblacionRepository
    {
        public readonly DbConnectionFactory _connectionString;
        public PoblacionCondicionRepository(DbConnectionFactory connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<int> CrearPoblacionAsync(string nombre)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", nombre);
            await connection.ExecuteAsync("CREARPOBLACION", parameters, commandType: CommandType.StoredProcedure);
            return 1;
        }
        public async Task<List<PoblacionCondicion>> ObtenerPoblacionAsync()
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var poblacionCondicion = await connection.QueryAsync<PoblacionCondicion>("OBTENERPOBLACION");
            return poblacionCondicion.ToList();
        }
        public async Task<int> EditarPoblacionAsync(int id, string nombre)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdPoblacion", id);
            parameters.Add("@Nombre", nombre);
            await connection.ExecuteAsync("EDITARPOBLACION", parameters, commandType: CommandType.StoredProcedure);
            return 1;
        }
        public async Task<int> EliminarPoblacionAsync(int id)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdPoblacion", id);
            await connection.ExecuteAsync("ELIMINARPOBLACION", parameters, commandType: CommandType.StoredProcedure);
            return 1;
        }
    }
}
