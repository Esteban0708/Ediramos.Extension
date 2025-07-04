using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Usuario;
using Ediramos.Extension.Aplicacion.DTOs.Usuario;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Usuario
{
    public class UserPrefijoHandler : IRequestHandler<PrefijoUserCommnand, List<UserPrefijoDTO>>
    {
        private readonly IPrefijoUserRepository _repo; 
        public UserPrefijoHandler(IPrefijoUserRepository repo) 
        {
            _repo = repo;
        }
        public async Task<List<UserPrefijoDTO>> Handle(PrefijoUserCommnand request, CancellationToken cancellationToken)
        {
            var usuarios = await _repo.BuscarPorPrefijoAsync(request.TextoBusqueda);

            var usuariosDto = usuarios.Select(u => new UserPrefijoDTO
            {
                Pege_id = u.PEGE_ID,
                NommbreCompleto = u.NNOMBRE_COMPLETO,
                DocumentoIdentidad= u.PEGE_DOCUMENTOIDENTTIDAD,
            }).ToList();
            return usuariosDto;
        }
    }
}
