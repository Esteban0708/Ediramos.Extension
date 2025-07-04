using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ediramos.Extension.Aplicacion.Commands.Objetivo;
using FluentValidation;

namespace Ediramos.Extension.Aplicacion.Validaciones.Objetivo
{
    public class CrearObjetivoValidator : AbstractValidator<CrearObjetivoCommand>
    {
        public CrearObjetivoValidator()
        {
            RuleFor(x => x.DTO.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.");

            RuleFor(x => x.DTO.Descripcion)
                .NotEmpty().WithMessage("La descripción es obligatoria.")
                .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres.");
        }
    }
}
