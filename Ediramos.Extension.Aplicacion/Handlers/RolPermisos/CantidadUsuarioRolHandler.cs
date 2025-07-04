using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.RolPermisos;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.RolPermisos
{
    public class CantidadUsuarioRolHandler : IRequestHandler<CantidadUsuarioRolQuery, List<CantidadUsuarioRolDTo>>
    {
        private readonly IRolRepository _repositorio;

        public CantidadUsuarioRolHandler(IRolRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<CantidadUsuarioRolDTo>> Handle(CantidadUsuarioRolQuery request, CancellationToken cancellationToken)
        {
            var resultado = await _repositorio.ContarUsuariosPorRolAsync();

            return resultado.Select(r => new CantidadUsuarioRolDTo
            {
                IdRol = r.IdRol,
                NombreRol = r.NombreRol,
                UsuarioAsignados = r.UsuariosAsignados
            }).ToList();
        }
    }
}
