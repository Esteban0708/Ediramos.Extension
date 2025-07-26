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
    public class GrupoRepository : IGrupoRepository
    {
        private readonly DbConnectionFactory _connectionString;
        public GrupoRepository(DbConnectionFactory configuration)
        {
            _connectionString = configuration;
        }
        public async Task<int> CrearGrupoAsync(string Nombre, string codigo, int fk_division)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", Nombre);
            parameters.Add("@Codigo", codigo);
            parameters.Add("@fk_Division", fk_division);

            await connection.ExecuteAsync("CREARGRUPO", parameters, commandType: System.Data.CommandType.StoredProcedure);
            return 1;

        }
        public async Task<List<Grupo>> ObtenerGrupoAsync()
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var grupos = await connection.QueryAsync<Grupo>("OBTENERGRUPODANE");
            return grupos.ToList();
        }
        public async Task EliminarGruponAsync(int id)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdGrupoDane", id);

            await connection.ExecuteAsync("ELIMINAR_GRUPODANE", parameters, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}

