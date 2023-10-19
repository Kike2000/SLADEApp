using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoSlade.Application.DTOs.Request
{
    public class RegistroRequestDTO
    {
        public Guid ParticipanteId { get; set; }
        public Guid EventoId { get; set; }
        public DateTime? HoraDeRegistro { get; set; }
        public bool Asistencia { get; set; }
    }
}
