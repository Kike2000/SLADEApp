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
