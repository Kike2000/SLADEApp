using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoSlade.Application.DTOs.Response.ParticipanteResponse
{
    public class ParticipanteResponseDTO
    {
        public Guid Id { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Procedencia { get; set; }
        public string? Institucion { get; set; }
    }
}
