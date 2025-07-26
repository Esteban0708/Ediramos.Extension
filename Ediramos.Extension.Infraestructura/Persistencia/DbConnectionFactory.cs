using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Oracle.ManagedDataAccess.Client;
using Ediramos.Extension.Infraestructura.Config;

namespace Ediramos.Extension.Infraestructura.Persistencia
{
    public class DbConnectionFactory
    {
        private readonly string _oracleConnectionString;
        private readonly string _sqlServerConnectionString;
        private readonly string _mongoConnectionString;
        private readonly IMongoDatabase _database;

        public DbConnectionFactory(IOptions<ConnectionSettings> options)
        {
            _oracleConnectionString = options.Value.OracleConnection;
            _sqlServerConnectionString = options.Value.SqlServerConnection;
            _mongoConnectionString = options.Value.MongoConnection;

            var mongoUrl = new MongoUrl(_mongoConnectionString);
            var client = new MongoClient(mongoUrl);
            _database = client.GetDatabase(options.Value.MongoDatabase);
        }

        public OracleConnection CreateOracleConnection()
        {
            return new OracleConnection(_oracleConnectionString);
        }

        public IDbConnection CreateSqlServerConnection()
        {
            return new SqlConnection(_sqlServerConnectionString);
        }

        public IMongoCollection<T> CreateMongoCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
        public IMongoDatabase CreateMongoDatabase()
        {
            return _database;
        }
    }
}
