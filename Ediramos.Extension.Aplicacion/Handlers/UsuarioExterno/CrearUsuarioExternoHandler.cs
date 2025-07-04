using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.UsuarioExterno;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.UsuarioExterno
{
    public class CrearUsuarioExternoHandler : IRequestHandler<CrearUsuarioExternoCommand, int>
    {
        private readonly IUsuarioExternoRepository _repository;

        public CrearUsuarioExternoHandler(IUsuarioExternoRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(CrearUsuarioExternoCommand request, CancellationToken cancellationToken)
        {
          return await _repository.CrearUsuarioExternoAsync(
                request.DTO.DocumentoIdentidad,
                request.DTO.Nombres,
                request.DTO.Apellidos,
                request.DTO.Correo,
                request.DTO.EPS
            );
        }
    }
}
