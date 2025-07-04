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
    public class ConvocatoriaRepository : IConvocatoriaRepository
    {
        private readonly DbConnectionFactory _connectionString; 

        public ConvocatoriaRepository(DbConnectionFactory connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> CrearConvocatoriaAsync(
            string titulo,
            string descripcion,
            string resolucion,
            string nResolucion,
            int? idModalidad,
            DateTime fechaInicio,
            DateTime fechaFin,
            int duracion,
            string objetivos,
            string lineas)
        {
            using var connection = _connectionString.CreateSqlServerConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@p_titulo", titulo);
            parameters.Add("@p_resolucion", resolucion);
            parameters.Add("@p_n_resolucion", nResolucion);
            parameters.Add("@p_descripcion", descripcion);
            parameters.Add("@p_fecha_inicio", fechaInicio);
            parameters.Add("@p_fecha_fin", fechaFin);
            parameters.Add("@p_duracion", duracion);

            parameters.Add("@p_modalidad", idModalidad.HasValue ? idModalidad.Value : (object)DBNull.Value, DbType.Int32);
            parameters.Add("@p_objetivos", objetivos ?? (object)DBNull.Value);
            parameters.Add("@p_lineas", string.IsNullOrEmpty(lineas) ? (object)DBNull.Value : lineas, DbType.String);

            var idConvocatoria = await connection.ExecuteScalarAsync<int>(
                "CREAR_CONVOCATORIA", parameters, commandType: CommandType.StoredProcedure);

            return idConvocatoria;
        }
        public async Task<List<Convocatoria>> ObtenerConvocatoriasBasicasAsync()
        {
            using var connection = _connectionString.CreateSqlServerConnection();

            var multi = await connection.QueryMultipleAsync("OBTENER_CONVOCATORIA_COMPLETA", commandType: CommandType.StoredProcedure);

            var convocatorias = (await multi.ReadAsync<Convocatoria>()).ToList();
            var objetivosSP = (await multi.ReadAsync<ObjetivoSP>()).ToList();
            var lineasSP = (await multi.ReadAsync<LineaSP>()).ToList();
            var itemsSP = (await multi.ReadAsync<ItemSP>()).ToList();

            foreach (var convocatoria in convocatorias)
            {
                convocatoria.Objetivos = objetivosSP
                    .Where(o => o.IdConvocatoria == convocatoria.IdConvocatoria)
                    .Select(o => new ObjetivoSP
                    {
                        IdObjetivo = o.IdObjetivo,
                        Nombre = o.Nombre
                    }).ToList();

                convocatoria.Lineas = lineasSP
                    .Where(l => l.IdConvocatoria == convocatoria.IdConvocatoria)
                    .Select(l => new LineaSP
                    {
                        IdLinea = l.IdLinea,
                        Nombre = l.Nombre,
                    }).ToList();

                convocatoria.Items = itemsSP
                    .Where(i => i.IdConvocatoria == convocatoria.IdConvocatoria)
                    .Select(i => new ItemSP
                    {
                        IdItem = i.IdItem,
                        Titulo = i.Titulo,
                        Pregunta = i.Pregunta,
                        PuntajeMax = i.PuntajeMax,
                        PuntajeMin = i.PuntajeMin
                    }).ToList();
            }

            return convocatorias;
        }


    }
}

