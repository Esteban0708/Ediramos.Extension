using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Proyecto;
using Ediramos.Extension.Aplicacion.Interfaces;
using Ediramos.Extension.Dominio.Entidades;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;
using MongoDB.Bson;

namespace Ediramos.Extension.Aplicacion.Handlers.Proyecto
{
    public class CrearProyectoAnexoHandler : IRequestHandler<CrearProyectoAnexoCommand, bool>
    {
        private readonly IProyectoAnexoRepository _repo;
        private readonly IAlmacenamientoMongo _fileStorage;

        public CrearProyectoAnexoHandler(IProyectoAnexoRepository repo, IAlmacenamientoMongo fileStorage)
        {
            _repo = repo;
            _fileStorage = fileStorage;

        }
        public async Task<bool> Handle(CrearProyectoAnexoCommand request, CancellationToken cancellationToken)
        {
            var referencias = request.Referencias.Split(',').Select(r => r.Trim()).ToList();

            var archivos = new List<AnexoArchivo>();
            if (request.Archivos != null && request.Archivos.Any())
            {
                foreach (var archivo in request.Archivos)
                {
                    using (var stream = archivo.OpenReadStream())
                    {
                        var idMongo = await _fileStorage.SubirArchivoAsync(stream, archivo.FileName, archivo.ContentType);

                        archivos.Add(new AnexoArchivo
                        {
                            Nombre = archivo.FileName,
                            Tipo = Path.GetExtension(archivo.FileName),
                            Ruta = idMongo
                        });
                    }
                }
            }

            var anexo = new ProyectoAnexo
            {
                Id = ObjectId.GenerateNewId(),
                IdProyecto = request.IdProyecto,
                Referencias = referencias,
                Archivos = archivos,
                AnexosTexto = request.AnexosTexto
            };

            await _repo.Insertar(anexo);
            return true;
        }
    }
}
