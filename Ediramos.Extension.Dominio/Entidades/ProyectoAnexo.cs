using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ediramos.Extension.Dominio.Entidades
{
    [BsonIgnoreExtraElements]
    public class ProyectoAnexo
    {
        public ProyectoAnexo()
        {
            Referencias = new List<string>();
            Archivos = new List<AnexoArchivo>();
            AnexosTexto = string.Empty;
        }

        [BsonId]
        public ObjectId Id { get; set; }
        public string IdProyecto { get; set; }
        public List<string> Referencias { get; set; }
        public List<AnexoArchivo> Archivos { get; set; }
        public string AnexosTexto { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class AnexoArchivo
    {
        public AnexoArchivo()
        {
            Nombre = string.Empty;
            Tipo = string.Empty;
            Ruta = string.Empty;
        }

        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Ruta { get; set; }
    }
}
