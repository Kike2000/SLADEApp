using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoSlade.Application.DTOs.Request
{
    public class ParticipanteRequestDTO
    {
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Procedencia { get; set; }
        public string? Institucion { get; set; }
    }
}
