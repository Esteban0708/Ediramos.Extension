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
using Oracle.ManagedDataAccess.Client;

namespace Ediramos.Extension.Infraestructura.Repositorios
{
    public class PrefijoRepository : IPrefijoUserRepository
    {
        private readonly DbConnectionFactory _connectionString;
        public PrefijoRepository(DbConnectionFactory configuration)
        {
            _connectionString = configuration;
        }
        public async Task<List<PersonaBuscador>> BuscarPorPrefijoAsync(string prefijo)
        {
            var personas = new List<PersonaBuscador>();

            using var connection = _connectionString.CreateOracleConnection();
            connection.Open();

            using var command = new OracleCommand("DES_EDRAMOS.BUSCARPERSOPORPREFIJO", connection);
            command.CommandType = CommandType.StoredProcedure;


            var paramPrefijo = new OracleParameter("PrefijoDocumento", OracleDbType.Varchar2, ParameterDirection.Input)
            {
                Value = prefijo
            };
            command.Parameters.Add(paramPrefijo);


            var paramCursor = new OracleParameter("ResultCursor", OracleDbType.RefCursor, ParameterDirection.Output);
            command.Parameters.Add(paramCursor);

            using var reader = await command.ExecuteReaderAsync(CommandBehavior.Default);

            while (await reader.ReadAsync())
            {
                var persona = new PersonaBuscador
                {
                    PEGE_ID = reader.GetInt32(reader.GetOrdinal("PEGE_ID")),
                    NNOMBRE_COMPLETO = reader.GetString(reader.GetOrdinal("NOMBRE_COMPLETO")),
                    PEGE_DOCUMENTOIDENTTIDAD = reader.GetString(reader.GetOrdinal("PEGE_DOCUMENTOIDENTIDAD"))
                };

                personas.Add(persona);
            }

            return personas;
        }

    }
}
