using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Rol;
using FluentValidation;

namespace Ediramos.Extension.Aplicacion.Validaciones.RolPermiso
{
    public class CrearRolValidator : AbstractValidator<CrearRolCommand>
    {
        public CrearRolValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().MaximumLength(90);
            RuleFor(x => x.ColorHex).NotEmpty().MaximumLength(10);
            RuleFor(x => x.Permisos).NotEmpty();
        }
    }

}
