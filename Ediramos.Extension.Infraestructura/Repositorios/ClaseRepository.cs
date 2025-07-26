using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Ediramos.Extension.Dominio.Entidades;
using Ediramos.Extension.Dominio.Repositorios;
using Ediramos.Extension.Infraestructura.Persistencia;

namespace Ediramos.Extension.Infraestructura.Repositorios
{
    public class ClaseRepository : IClaseRepository
    {
        private readonly DbConnectionFactory _connectionString;
        public ClaseRepository(DbConnectionFactory configuration)
        {
            _connectionString = configuration;
        }
        public async Task<int> CrearClaseAsync(string nombre, string codigo, int fk_grupo)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", nombre);
            parameters.Add("@Codigo", codigo);
            parameters.Add("@fk_grupo", fk_grupo);
            await connection.ExecuteAsync("CREARCLASE", parameters, commandType: System.Data.CommandType.StoredProcedure);
            return 1;
        }
        public async Task<List<Clase>> ObtenerClaseAsync()
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var clases = await connection.QueryAsync<Clase>("OBTENERCLASE");
            return clases.ToList();
        }
        public async Task EliminarClaseAsync(int id)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdClase", id);
            await connection.ExecuteAsync("ELIMINAR_CLASE", parameters, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
