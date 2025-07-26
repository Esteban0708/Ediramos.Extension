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
using MongoDB.Driver;
using Oracle.ManagedDataAccess.Client;

namespace Ediramos.Extension.Infraestructura.Repositorios
{
    public class InfoCoordinadorRepository : IInforCoordinadorRepository
    {
        private readonly DbConnectionFactory _connectionString;
        public InfoCoordinadorRepository(DbConnectionFactory configuration)
        {
            _connectionString = configuration;
        }
        public async Task<List<InfoCoodinador>> ObtenerInformacionAsync(string documento)
        {
            using var connection = _connectionString.CreateOracleConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = "CONSULINFOCOORDINADOR";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new OracleParameter("p_documento", OracleDbType.Varchar2, documento, ParameterDirection.Input));

            var cursor = new OracleParameter("p_resultado", OracleDbType.RefCursor, ParameterDirection.Output);
            command.Parameters.Add(cursor);

            using var reader = await command.ExecuteReaderAsync();
            var result = new List<InfoCoodinador>();

            while (await reader.ReadAsync())
            {
                result.Add(new InfoCoodinador
                {
                    Pege_id = reader.GetInt32(reader.GetOrdinal("PEGE_ID")),
                    Documento = reader.GetString(reader.GetOrdinal("DOCUMENTO")),
                    Peng_emailinstitucional = reader.GetString(reader.GetOrdinal("PENG_EMAILINSTITUCIONAL")),
                    Pege_Telefono = reader.GetString(reader.GetOrdinal("PEGE_TELEFONOCELULAR"))
                });
            }

            return result;
        }
        public async Task<List<Semestre>> ObtenerSemestreAsync(string documento)
        {
            using var connection = _connectionString.CreateOracleConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = "CONSULTARSEMESTRE";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new OracleParameter("p_documento", OracleDbType.Varchar2, documento, ParameterDirection.Input));
            var cursor = new OracleParameter("p_resultado", OracleDbType.RefCursor, ParameterDirection.Output);
            command.Parameters.Add(cursor);

            using var reader = await command.ExecuteReaderAsync();
            var result = new List<Semestre>();
            while (reader.Read())
            {
                result.Add(new Semestre
                {
                    Pege_id = reader.GetInt32(reader.GetOrdinal("PEGE_ID")),
                    Documento = reader.GetString(reader.GetOrdinal("DOCUMENTO")),
                    Estp_semestreactual = reader.IsDBNull(reader.GetOrdinal("ESTP_SEMESTREACTUAL"))? 0 : reader.GetInt32(reader.GetOrdinal("ESTP_SEMESTREACTUAL"))
                });
            }
            return result;

        }
    }
}
