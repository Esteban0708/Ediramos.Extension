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
    public class LineaRepository : ILineaRepository
    {
        public readonly DbConnectionFactory _connectionString; 

        public LineaRepository(DbConnectionFactory connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> CrearLineaAsync(string nombre)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters(); 
            parameters.Add("@Nombre", nombre);

            await connection.ExecuteAsync("CREARLINEAPROFUNDIZACION", parameters, commandType : CommandType.StoredProcedure);
            return 1; 
        }

        public async Task<List<LineaPorfundizacion>> ObtenerLineasAsync()
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var lineas = await connection.QueryAsync <LineaPorfundizacion>("OBTENERLINEAS");
            return lineas.ToList();
        }
        
        public async Task<int> EditarLineaAsync(int id, string nombre)
        {
            using var connection = _connectionString.CreateSqlServerConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@IdLinea", id);
            parameters.Add("@Nombre", nombre);

            await connection.ExecuteAsync("EDITARLINEAPROFUNDIZACION", parameters, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public async Task<int> EliminarLineaAsync(int id)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdLinea", id);

            await connection.ExecuteAsync("ELIMINARLINEAPROFUNDIZACION", parameters, commandType: CommandType.StoredProcedure);
            return 1;
        }
    }
}
