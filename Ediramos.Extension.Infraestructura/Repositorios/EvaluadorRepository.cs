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
    public class EvaluadorRepository : IEvaluadorRespository
    {
        private readonly DbConnectionFactory _connectionString;

        public EvaluadorRepository(DbConnectionFactory configuration)
        {
            _connectionString = configuration;
        }

        public async Task<bool> AsignarEvaluadorAsync(AsignarEvaluador evaluador)
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@IdProyecto", evaluador.IdProyecto);
            parameters.Add("@PEGE_ID", evaluador.PEGE_ID);
            parameters.Add("@Documento", evaluador.Documento);
            parameters.Add("@NombreCompleto", evaluador.NombreCompleto);
            parameters.Add("@IdTipoJurado", evaluador.IdTipoJurado);
            var result = await connection.ExecuteAsync("ASIGNAREVALUADORES", parameters, commandType: System.Data.CommandType.StoredProcedure);
            return result > 0;
        }
    }
}
