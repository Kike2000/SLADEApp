using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoSlade.Application.DTOs.Request
{
    public class EventoRequestDTO
    {
        public string? Nombre { get; set; }
        public int Cupo { get; set; }
        public Guid AreaId { get; set; }
        public bool AgendaAbierta { get; set; }
    }
}
