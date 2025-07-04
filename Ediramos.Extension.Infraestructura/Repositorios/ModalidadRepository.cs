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
    public class ModalidadRepository : IModalidadRepository
    {
        public readonly DbConnectionFactory _connectionString;

        public ModalidadRepository(DbConnectionFactory connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> CrearModalidadAsync(string nombre)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", nombre);
            await connection.ExecuteAsync("CREARMODALIDAD", parameters, commandType: CommandType.StoredProcedure);
            return 1;
        }
        public async Task<List<Modalidad>> ObtenerModalidadesAsync()
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var modalidades = await connection.QueryAsync<Modalidad>("OBTENERMODALIDAD");
            return modalidades.ToList();
        }
        public async Task<int> EditarModalidadAsync(int id, string nombre)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdModalidad", id);
            parameters.Add("@Nombre", nombre);
            await connection.ExecuteAsync("EDITARMODALIDAD", parameters, commandType: CommandType.StoredProcedure);
            return 1;
        }
        public async Task<int> EliminarModalidadAsync(int id)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdModalidad", id);
            await connection.ExecuteAsync("ELIMINARMODALIDAD", parameters, commandType: CommandType.StoredProcedure);
            return 1;
        }
    }
}
