using CongresoSlade.Application.DTOs.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoSlade.Application.Validators.Registro
{
    public class RegistroValidator : AbstractValidator<RegistroRequestDTO>
    {
        public RegistroValidator()
        {
            RuleFor(c => c.EventoId).NotNull().WithMessage("Nombre no puede ser nulo")
               .NotEmpty().WithMessage("Nombre no puede ser vacío");
        }
    }
}
