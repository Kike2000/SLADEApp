using CongresoSlade.Application.DTOs.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoSlade.Application.Validators.Evento
{
    public class EventoValidator : AbstractValidator<EventoRequestDTO>
    {
        public EventoValidator()
        {
            RuleFor(c => c.Nombre).NotNull().WithMessage("Nombre no puede ser nulo")
                .NotEmpty().WithMessage("Nombre no puede ser vacío");
        }
    }
}
