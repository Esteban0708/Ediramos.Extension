using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;
using Ediramos.Extension.Dominio.Repositorios;
using Ediramos.Extension.Infraestructura.Persistencia;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Ediramos.Extension.Infraestructura.Repositorios
{
    public class ProyectoAnexoRepository : IProyectoAnexoRepository
    {
        private readonly DbConnectionFactory _ConnectionString;
        private const string NombreColeccion = "proyectoAnexos";

        public ProyectoAnexoRepository (DbConnectionFactory connectionString)
        {
            _ConnectionString = connectionString;
        }
        public async Task Insertar(ProyectoAnexo anexo)
        {
            try
            {
                var coleccion = _ConnectionString.CreateMongoCollection<ProyectoAnexo>("proyectoAnexos");
                await coleccion.InsertOneAsync(anexo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("🔥 ERROR Mongo => " + ex.Message);
                Console.WriteLine("🧠 StackTrace: " + ex.StackTrace);
                throw;
            }
        }
        public async Task<ProyectoAnexo?> ObtenerPorProyectoAsync(string idProyecto)
        {
            try
            {
                var coleccion = _ConnectionString.CreateMongoCollection<ProyectoAnexo>(NombreColeccion);
                return await coleccion.Find(x => x.IdProyecto == idProyecto).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error obteniendo proyectoAnexo: " + ex.Message);
                throw;
            }
        }



    }
}
