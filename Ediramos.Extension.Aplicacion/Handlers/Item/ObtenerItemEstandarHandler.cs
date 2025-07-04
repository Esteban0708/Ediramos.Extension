using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Queries;
using Ediramos.Extension.Dominio.Entidades;
using Ediramos.Extension.Dominio.Repositorios;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Handlers.Item
{
    public class ObtenerItemEstandarHandler : IRequestHandler<ObtenerItemEstandarQuery, List<ItemEstandar>>
    {
        private readonly IItemsRepository _repository;
        public ObtenerItemEstandarHandler(IItemsRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ItemEstandar>> Handle(ObtenerItemEstandarQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerItemsEstandarAsync();
        }
    }
}
