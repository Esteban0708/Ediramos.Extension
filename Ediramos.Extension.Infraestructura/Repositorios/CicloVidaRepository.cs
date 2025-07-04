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
    public class CicloVidaRepository : ICicloVidaRepository
    {
        public readonly DbConnectionFactory _connectionString;
        public CicloVidaRepository(DbConnectionFactory connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<int> CrearCicloVidaAsync(string nombre)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", nombre);
            await connection.ExecuteAsync("CREARCICLOVIDA", parameters, commandType: CommandType.StoredProcedure);
            return 1;
        }
        public async Task<List<CicloVida>> ObtenerCicloVidaAsync()
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var ciclosVida = await connection.QueryAsync<CicloVida>("OBTENERCICLOVIDA");
            return ciclosVida.ToList();
        }
        public async Task<int> EditarCicloVidaAsync(int id, string nombre)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdCicloVida", id);
            parameters.Add("@Nombre", nombre);
            await connection.ExecuteAsync("EDITARCICLOVIDA", parameters, commandType: CommandType.StoredProcedure);
            return 1;
        }
        public async Task<int> EliminarCicloVidaAsync(int id)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdCicloVida", id);
            await connection.ExecuteAsync("ELIMINARCICLOVIDA", parameters, commandType: CommandType.StoredProcedure);
            return 1;

        }
    }
}
