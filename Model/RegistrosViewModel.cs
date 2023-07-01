namespace CongresoServer.Model
{
    public class RegistrosViewModel
    {
        public Guid Id { get; set; }
        public Guid ParticipanteId { get; set; }
        public Guid EventoId { get; set; }
        public string? NombreParticipante { get; set; }
        public string? Email { get; set; }
        public string? Procedencia { get; set; }
        public string? NombreEvento { get; set; }
        public DateTime? HoraDeRegistro { get; set; }

        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TotalAsistencias { get; set; }
        public int Registros { get; set; }
    }
}
