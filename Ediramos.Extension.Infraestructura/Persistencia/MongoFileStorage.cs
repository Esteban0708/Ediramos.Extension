using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Ediramos.Extension.Infraestructura.Config;
using Ediramos.Extension.Aplicacion.Interfaces;
using Ediramos.Extension.Dominio.Entidades;

namespace Ediramos.Extension.Infraestructura.Persistencia
{
    public class MongoFileStorage : IAlmacenamientoMongo
    {
        private readonly string _rutaBase = "wwwroot/anexos";

        public async Task<string> SubirArchivoAsync(Stream stream, string nombreArchivo, string tipo)
        {
            var nombre = $"{Guid.NewGuid()}_{nombreArchivo}";
            var rutaCompleta = Path.Combine(_rutaBase, nombre);

            Directory.CreateDirectory(_rutaBase); 

            using (var fileStream = new FileStream(rutaCompleta, FileMode.Create))
            {
                await stream.CopyToAsync(fileStream);
            }

            return nombre; 
        }

        public async Task<ArchivoDescargado> DescargarArchivoAsync(string idArchivo)
        {
            return new ArchivoDescargado
            {
                Contenido = new byte[0],
                Nombre = "archivo",
                Tipo = "application/octet-stream"
            };
        }
    }

}
