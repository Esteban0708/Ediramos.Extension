using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Usuario;
using FluentValidation;

namespace Ediramos.Extension.Aplicacion.Validaciones.Usuario
{
    public class BuscadorValidator : AbstractValidator<PrefijoUserCommnand>
    {
        public BuscadorValidator()
        {
            RuleFor(x => x.TextoBusqueda)
                .NotEmpty().WithMessage("El campo 'Documento' es obligatorio.")
                .MinimumLength(3).WithMessage("El campo 'Documento' debe tener al menos 3 caracteres.");
        }
    }
}
