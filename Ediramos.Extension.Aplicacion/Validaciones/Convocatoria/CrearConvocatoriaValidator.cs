using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.DTOs.Convocatoria;
using FluentValidation;

namespace Ediramos.Extension.Aplicacion.Validaciones.Convocatoria
{
    public class CrearConvocatoriaValidator : AbstractValidator<CrearConvocatoriaDto>
    {
        public CrearConvocatoriaValidator()
        {
            RuleFor(x => x.Titulo).NotEmpty().WithMessage("El título es obligatorio.");
            RuleFor(x => x.Descripcion).NotEmpty().WithMessage("La descripción es obligatoria.");
            RuleFor(x => x.FechaInicio).LessThan(x => x.FechaFin)
                .WithMessage("La fecha de inicio debe ser menor que la fecha de fin.");
        }
    }
}
