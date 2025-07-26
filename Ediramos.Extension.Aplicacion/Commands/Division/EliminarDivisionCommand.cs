using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ediramos.Extension.Aplicacion.Commands.Division
{
    public class EliminarDivisionCommand : IRequest<int>
    {  
        public int IdDivision { get; set; }
        public EliminarDivisionCommand(int idDivision) 
        { 
            IdDivision = idDivision;
        }
    }
}
