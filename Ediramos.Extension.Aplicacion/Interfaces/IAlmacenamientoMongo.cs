using System.IO;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ediramos.Extension.Aplicacion.Interfaces
{
    public interface IAlmacenamientoMongo
    {
        Task<string> SubirArchivoAsync(Stream stream, string nombreArchivo, string tipo);
        Task<ArchivoDescargado> DescargarArchivoAsync(string idArchivo);

    }
}
