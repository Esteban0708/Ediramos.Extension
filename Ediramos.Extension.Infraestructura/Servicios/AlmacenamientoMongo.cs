using Ediramos.Extension.Aplicacion.Interfaces;
using Ediramos.Extension.Dominio.Entidades;
using Ediramos.Extension.Infraestructura.Persistencia;
using MongoDB.Bson;
using MongoDB.Driver;

public class AlmacenamientoMongo : IAlmacenamientoMongo
{
    private readonly IMongoDatabase _database;

    public AlmacenamientoMongo(DbConnectionFactory dbFactory)
    {
        _database = dbFactory.CreateMongoDatabase();
    }
    public async Task<string> SubirArchivoAsync(Stream stream, string nombreArchivo, string tipo)
    {
        using var memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream);

        var ruta = $"{Guid.NewGuid()}_{nombreArchivo}";

        var documento = new BsonDocument
    {
        { "nombre", nombreArchivo },
        { "tipo", tipo },
        { "contenido", new BsonBinaryData(memoryStream.ToArray()) },
        { "fecha", DateTime.UtcNow },
        { "ruta", ruta } 
    };

        var coleccion = _database.GetCollection<BsonDocument>("archivos");
        await coleccion.InsertOneAsync(documento);

        return ruta;
    }

    public async Task<ArchivoDescargado> DescargarArchivoAsync(string rutaArchivo)
    {
        var proyectoAnexos = _database.GetCollection<BsonDocument>("proyectoAnexos");
        var filtroAnexo = Builders<BsonDocument>.Filter.ElemMatch<BsonDocument>(
     "Archivos",
     Builders<BsonDocument>.Filter.Eq("Ruta", rutaArchivo)
 );

        var docAnexo = await proyectoAnexos.Find(filtroAnexo).FirstOrDefaultAsync();

        if (docAnexo == null)
            throw new FileNotFoundException("❌ Ruta no encontrada en proyectoAnexos");

        var archivos = _database.GetCollection<BsonDocument>("archivos");
        var filtroArchivo = Builders<BsonDocument>.Filter.Eq("ruta", rutaArchivo);
        var docArchivo = await archivos.Find(filtroArchivo).FirstOrDefaultAsync();

        if (docArchivo == null || !docArchivo.Contains("contenido"))
            throw new FileNotFoundException("❌ Archivo binario no encontrado en 'archivos'");

        var contenido = docArchivo["contenido"].AsByteArray;
        var nombre = docArchivo["nombre"].AsString;
        var tipo = docArchivo.Contains("tipo") ? docArchivo["tipo"].AsString : "application/octet-stream";

        return new ArchivoDescargado
        {
            Contenido = contenido,
            Nombre = nombre,
            Tipo = ObtenerTipoMime(tipo)
        };
    }

    private string ObtenerTipoMime(string extension)
    {
        extension = extension.ToLowerInvariant().TrimStart('.');

        return extension switch
        {
            "pdf" => "application/pdf",
            "jpg" or "jpeg" => "image/jpeg",
            "png" => "image/png",
            "docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            "pptx" => "application/vnd.openxmlformats-officedocument.presentationml.presentation",
            "xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            _ => "application/octet-stream"
        };
    }


}
