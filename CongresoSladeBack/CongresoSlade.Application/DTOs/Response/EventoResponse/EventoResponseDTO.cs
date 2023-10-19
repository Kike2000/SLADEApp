namespace CongresoSlade.Application.DTOs.Response.EventoResponse
{
    public class EventoResponseDTO
    {
        public Guid Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? HoraInicio { get; set; }
        public DateTime? HoraTermino { get; set; }
        public Guid AreaId { get; set; }
        public int Cupo { get; set; }
        public bool AgendaAbierta { get; set; }
        public bool Desasociar { get; set; }
    }
}
