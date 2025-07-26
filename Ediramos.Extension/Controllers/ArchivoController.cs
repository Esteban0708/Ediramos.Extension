using Ediramos.Extension.Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ArchivoController : ControllerBase
{
    private readonly IAlmacenamientoMongo _almacenamiento;

    public ArchivoController(IAlmacenamientoMongo almacenamiento)
    {
        _almacenamiento = almacenamiento;
    }

    [HttpGet("{idArchivo}")]
    public async Task<IActionResult> DescargarArchivo(string idArchivo)
    {
        try
        {
            var archivo = await _almacenamiento.DescargarArchivoAsync(idArchivo);
            return File(archivo.Contenido, archivo.Tipo, archivo.Nombre);
        }
        catch (FormatException)
        {
            return BadRequest("ID inválido");
        }
        catch (FileNotFoundException)
        {
            return NotFound("Archivo no encontrado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error inesperado: {ex.Message}");
        }
    }

}
