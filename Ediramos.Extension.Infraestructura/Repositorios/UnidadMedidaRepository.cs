using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Ediramos.Extension.Dominio.Entidades;
using Ediramos.Extension.Dominio.Repositorios;
using Ediramos.Extension.Infraestructura.Persistencia;
using MongoDB.Driver.Core.Configuration;

namespace Ediramos.Extension.Infraestructura.Repositorios
{
    public class UnidadMedidaRepository : IUnidadMedidaRepository
    {
        private readonly DbConnectionFactory _connectionString;    

        public UnidadMedidaRepository(DbConnectionFactory connection)
        {
            _connectionString = connection;
        }
        public async Task<int> CrearUnidadMedidaAsync(string Nombre, string Descripcion)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters(); 
            parameters.Add("@Nombre", Nombre);
            parameters.Add("@Descripcion", Descripcion);

            await connection.ExecuteAsync("CREARUNIDADMEDIDA", parameters, commandType: System.Data.CommandType.StoredProcedure);
            return 1; 
        }
        public async Task<List<UnidadMedida>> ObtenerUnidadMedidaAsync()
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var unidadMedida = await connection.QueryAsync<UnidadMedida>("OBTENERUNIDADMEDIDA");
            return unidadMedida.ToList();
        }
    }
}
