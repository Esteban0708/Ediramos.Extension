using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Ediramos.Extension.Dominio.Entidades;
using Ediramos.Extension.Dominio.Repositorios;
using Ediramos.Extension.Infraestructura.Persistencia;
using Microsoft.Data.SqlClient;

namespace Ediramos.Extension.Infraestructura.Repositorios
{
    public class ObjetivoRepository : IObjetivoRepository
    {
        private readonly DbConnectionFactory _connectionString;

        public ObjetivoRepository(DbConnectionFactory configuration)
        {
            _connectionString = configuration;
        }


        public async Task<int> CrearObjetivoAsync(string nombre, string descripcion)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", nombre);
            parameters.Add("@Descripcion", descripcion);

            await connection.ExecuteAsync("CREAROBJETIVO", parameters, commandType: CommandType.StoredProcedure);

            return 1;
        }
        public async Task<List<Objetivo>> ObtenerObjetivosAsync()
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var objetivos = await connection.QueryAsync<Objetivo>("OBTENEROBJETIVO");
            return objetivos.ToList();
        }

        public async Task<int> EditarObjetivoAsync(int idObjetivo, string nombre, string descripcion)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parametros = new DynamicParameters();
            parametros.Add("@IdObjetivo", idObjetivo);
            parametros.Add("@Nombre", nombre);
            parametros.Add("@Descripcion", descripcion);
            await connection.ExecuteAsync("EDITAROBJETIVO", parametros, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public async Task<int> EliminarObjetivoAsync(int id)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdObjetivo", id);
            await connection.ExecuteAsync("ELIMINAROBJETIVO", parameters, commandType: CommandType.StoredProcedure);

            return 1;
           
        }

    }
}
