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
    public class ItemRepository : IItemsRepository
    {
        private readonly DbConnectionFactory _connectionString; 

        public ItemRepository(DbConnectionFactory connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<List<ItemEstandar>> ObtenerItemsEstandarAsync()
        {
            using var connection = _connectionString.CreateSqlServerConnection();
            var result = await connection.QueryAsync<ItemEstandar>("ITEMS_ESTANDAR");
            return result.ToList();
        }
        public async Task AsignarItemConvocatoriaAsync(
            string titulo,
            string pregunta,
            bool esEstandar,
            bool estado,
            int idConvocatoria,
            float puntajeMax,
            float puntajeMin)
        {
            using var connection = _connectionString.CreateSqlServerConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@p_titulo", titulo);
            parameters.Add("@p_pregunta", pregunta);
            parameters.Add("@p_esEstandar", esEstandar);
            parameters.Add("@p_estado", estado);
            parameters.Add("@p_idConvocatoria", idConvocatoria);
            parameters.Add("@p_puntajeMax", puntajeMax);
            parameters.Add("@p_puntajeMin", puntajeMin);

            await connection.ExecuteAsync(
                "ASIGNAR_ITEM_CONVOCATORIA",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
