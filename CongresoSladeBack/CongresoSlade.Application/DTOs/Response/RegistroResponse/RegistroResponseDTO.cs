using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoSlade.Application.DTOs.Response.RegistroResponse
{
    public class RegistroResponseDTO
    {
        public Guid Id { get; set; }
        public Guid ParticipanteId { get; set; }
        public Guid EventoId { get; set; }
        public DateTime? HoraDeRegistro { get; set; }
        public bool Asistencia { get; set; }
    }
}
