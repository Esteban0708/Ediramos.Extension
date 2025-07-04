using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Dominio.Entidades;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Queries
{
    public class ObtenerItemEstandarQuery : IRequest<List<ItemEstandar>>{

    }
}
