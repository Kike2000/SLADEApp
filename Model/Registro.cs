namespace CongresoServer.Model
{
    public class Registro
    {
        public Guid Id { get; set; }
        public Guid ParticipanteId { get; set; }
        public Guid EventoId { get; set; }
        public DateTime? HoraDeRegistro { get; set; }
        public bool Asistencia { get; set; } = false;
    }
}
