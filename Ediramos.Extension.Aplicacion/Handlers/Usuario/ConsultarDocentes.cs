using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Usuario;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Usuario
{
    public class ConsultarDocentes : IRequestHandler<ObtenerDocenteQuery, List<ConsultarDocenteDTo>>
    {
        private readonly IUsuarioRepository _repo;

        public ConsultarDocentes(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ConsultarDocenteDTo>> Handle(ObtenerDocenteQuery request, CancellationToken cancellationToken)
        {
            var docentes = await _repo.BuscarDocentesAsync("");

            if (string.IsNullOrWhiteSpace(request.Filtro))
            {
                return docentes.Select(e => new ConsultarDocenteDTo
                {
                    pege_id = e.pege_id,
                    documento = e.documento,
                    nombreCompleto = e.nombreCompleto,
                    programa = e.programa,
                    dependencia = e.dependencia
                }).ToList();
            }

            var palabras = request.Filtro.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var docentesFiltrados = docentes.Where(e =>
            {
                var texto = (e.nombreCompleto + " " + e.documento + " " + e.programa + " " + e.dependencia)
                                .ToLower();
                return palabras.All(p => texto.Contains(p));
            });

            return docentesFiltrados.Select(e => new ConsultarDocenteDTo
            {
                pege_id = e.pege_id,
                documento = e.documento,
                nombreCompleto = e.nombreCompleto,
                programa = e.programa,
                dependencia = e.dependencia
            }).ToList();

        }
    }

}
