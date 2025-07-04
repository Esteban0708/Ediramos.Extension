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
    public class PermisosRepository : IPermisosRepository
    {
        private readonly DbConnectionFactory _connectionString; 

        public PermisosRepository(DbConnectionFactory connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Permisos>> ObtenerPermisosAsync()
        {
            using var connection = _connectionString.CreateSqlServerConnection();

            var permisos = await connection.QueryAsync<Permisos>(
                "OBTENERPERMISOS",
                commandType: CommandType.StoredProcedure
            );

            return permisos.ToList();
        }

    }
}
