using CongresoSlade.Application.DTOs.Request;
using CongresoSlade.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoSlade.Application.Validators.Participante
{
    public class ParticipanteValidator : AbstractValidator<ParticipanteRequestDTO>
    {
        public ParticipanteValidator()
        {
            RuleFor(c => c.Nombre).NotNull().WithMessage("Nombre no puede ser nulo")
               .NotEmpty().WithMessage("Nombre no puede ser vacío");
        }
    }
}
