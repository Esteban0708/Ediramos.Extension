using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Objetivo;
using MediatR;
using Ediramos.Extension.Dominio.Repositorios;


namespace Ediramos.Extension.Aplicacion.Handlers.Objetivo
{
    public class CrearObjetivoHandler : IRequestHandler<CrearObjetivoCommand, int>
    {
        private readonly IObjetivoRepository _repo;

        public CrearObjetivoHandler(IObjetivoRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(CrearObjetivoCommand request, CancellationToken cancellationToken)
        {
            return await _repo.CrearObjetivoAsync(
                request.DTO.Nombre,
                request.DTO.Descripcion
            );
        }
    }
}
