using CongresoSlade.Application.DTOs.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoSlade.Application.Validators.Area
{
    public class AreaValidator : AbstractValidator<AreaRequestDTO>
    {
        public AreaValidator()
        {
            RuleFor(x => x.Nombre).NotNull().WithMessage("Nombre no puede ser núlo").NotEmpty().WithMessage("Nombre no puede estar vacío");
        }
    }
}
