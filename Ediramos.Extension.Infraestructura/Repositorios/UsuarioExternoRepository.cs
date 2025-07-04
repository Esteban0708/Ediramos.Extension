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
    public class UsuarioExternoRepository : IUsuarioExternoRepository
    {
        public readonly DbConnectionFactory _connectionString;
        public UsuarioExternoRepository(DbConnectionFactory connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<int> CrearUsuarioExternoAsync(
            long documentoIdentidad,
            string nombres,
            string apellidos,
            string correo,
            string eps
        )
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@DocumentoIdentidad", documentoIdentidad);
            parameters.Add("@Nombres", nombres);
            parameters.Add("@Apellidos", apellidos);
            parameters.Add("@Correo", correo);
            parameters.Add("@EPS", eps);
            await connection.ExecuteAsync("CREARUSUARIOEXTERNO", parameters, commandType: CommandType.StoredProcedure);
            return 1; 
        }
        public async Task<List<UsuarioExterno>> ObtenerUsuarioExternoAsync(string documentoParcial)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@DocumentoParcial", documentoParcial);

            var result = await connection.QueryAsync<UsuarioExterno>(
                "OBTENERUSUARIOSEXTERNOS",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }

    }
}
