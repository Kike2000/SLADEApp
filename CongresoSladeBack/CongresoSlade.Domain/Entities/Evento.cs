using System;
using System.Collections.Generic;

namespace CongresoSlade.Domain.Entities
{
    public partial class Evento : BaseEntity
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? HoraInicio { get; set; }
        public DateTime? HoraTermino { get; set; }
        public int Cupo { get; set; }
        public bool Desasociar { get; set; }
        public bool AgendaAbierta { get; set; }
        public Guid AreaId { get; set; }
    }
}
