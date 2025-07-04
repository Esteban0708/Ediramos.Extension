using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;

namespace Ediramos.Extension.Infraestructura.Persistencia
{
    public class DbConnectionFactory
    {
        private readonly string _oracleConnectionString;
        private readonly string _sqlServerConnectionString;

        public DbConnectionFactory(IOptions<Config.ConnectionSettings> options)
        {
            _oracleConnectionString = options.Value.OracleConnection;
            _sqlServerConnectionString = options.Value.SqlServerConnection;
        }
        public OracleConnection CreateOracleConnection()
        {
            return new OracleConnection(_oracleConnectionString);
        }
        public IDbConnection CreateSqlServerConnection()
        {
            return new SqlConnection(_sqlServerConnectionString);
        }
    }
}
