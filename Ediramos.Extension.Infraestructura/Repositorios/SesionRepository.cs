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
    public class SesionRepository : ISesionRepository
    {
        private readonly DbConnectionFactory _connectionString;
        public SesionRepository(DbConnectionFactory configuration)
        {
            _connectionString = configuration;
        }

        public async Task<int> CrearSesionAsync(string Nombre, string codigo)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters  = new DynamicParameters();
            parameters.Add("@Nombre", Nombre);
            parameters.Add("@Codigo", codigo);

            await connection.ExecuteAsync("CREARSESION", parameters, commandType: System.Data.CommandType.StoredProcedure);
            return 1;

        }
        public async Task<List<Sesion>> ObtenerSesionesAsync()
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var sesiones = await connection.QueryAsync<Sesion>("OBTENERSESIONES");
            return sesiones.ToList();
        }
        public async Task EliminarSesionAsync(int id)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdSesion", id);

            await connection.ExecuteAsync("ELIMINAR_SECCION", parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

    }

}
