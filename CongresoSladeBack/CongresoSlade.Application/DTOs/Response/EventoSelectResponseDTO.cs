using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoSlade.Application.DTOs.Response
{
    public class EventoSelectResponseDTO
    {
        public Guid Id { get; set; }
        public string? Nombre { get; set; }
    }
}
