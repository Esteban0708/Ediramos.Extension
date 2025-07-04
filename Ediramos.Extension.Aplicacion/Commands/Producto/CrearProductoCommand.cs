using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Producto;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Producto
{
    public class CrearProductoCommand : IRequest<int>
    {
        public CrearProductoDTo DTO { get; }
        public CrearProductoCommand(CrearProductoDTo dto)
        {
            DTO = dto;
        }
    }

}
