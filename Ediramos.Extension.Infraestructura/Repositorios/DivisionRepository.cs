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
    public class DivisionRepository : IDivisionRepository
    {
        private readonly DbConnectionFactory _connectionString;
        public DivisionRepository(DbConnectionFactory configuration)
        {
            _connectionString = configuration;
        }
        public async Task<int> CrearDivisionAsync(string Nombre, string codigo, int fk_sesion)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", Nombre);
            parameters.Add("@Codigo", codigo);
            parameters.Add("@fk_Sesion", fk_sesion);

            await connection.ExecuteAsync("CREARDIVISION", parameters, commandType: System.Data.CommandType.StoredProcedure);
            return 1;

        }
        public async Task<List<Division>> ObtenerDivisionAsync()
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var divisiones = await connection.QueryAsync<Division>("OBTENERDIVISIONES");
            return divisiones.ToList();
        }
        public async Task EliminarDivisionAsync(int id)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdDivision", id);

            await connection.ExecuteAsync("ELIMINARDIVISION", parameters, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
