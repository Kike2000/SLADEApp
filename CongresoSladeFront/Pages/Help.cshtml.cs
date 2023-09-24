using CongresoServer.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CongresoServer.Pages
{
    [Authorize(Roles = "Administrator, SysAdmin, Standard, Client")]
    public class HelpModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public HelpModel(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public class NuevoParticipante
        {
            public string Nombre { get; set; }
            public string Apellidos { get; set; }
            public string Email { get; set; }
            public string Procedencia { get; set; }
        }
        //public async Task RegistroParticipantes()
        //{
        //    var todosParticipantes = _dbContext.Participante.ToList();
        //    var participantes = JsonConvert.DeserializeObject<List<NuevoParticipante>>(System.IO.File.ReadAllText("wwwroot/participantes.json"));
        //    var participantesNoRepetidos = participantes.Where(p => p.Email != null && p.Email != "0" && p.Email.Contains("@")).ToList();
        //    var newest = new List<NuevoParticipante>();
        //    foreach (var item in participantesNoRepetidos)
        //    {
        //        if (item.Email.Contains(" "))
        //        {
        //            item.Email = item.Email.Replace(" ", "");
        //        }
        //        if (newest.Any(p => p.Email.Contains(item.Email)))
        //        {

        //        }
        //        else
        //        {
        //            newest.Add(item);
        //        }
        //    }
        //    var eventos27 = _dbContext.Evento.Where(p => p.HoraInicio.Value.Day == 27 && p.HoraInicio.Value.Hour < 13).ToList();
        //    var eventos28 = _dbContext.Evento.Where(p => p.HoraInicio.Value.Day == 28 && p.HoraInicio.Value.Hour < 13).ToList();
        //    var eventos29 = _dbContext.Evento.Where(p => p.HoraInicio.Value.Day == 29 && p.HoraInicio.Value.Hour < 13).ToList();
        //    foreach (var item in newest)
        //    {
        //        var participante = new Model.Participante
        //        {
        //            Email = item.Email,
        //            Procedencia = item.Procedencia,
        //            Nombre = $"{item.Nombre} {item.Apellidos}"
        //        };
        //        _dbContext.Participante.Add(participante);
        //        await _dbContext.SaveChangesAsync();
        //        foreach (var evento in eventos27)
        //        {
        //            var Registro = new Model.Registro
        //            {
        //                EventoId = evento.Id,
        //                ParticipanteId = participante.Id,
        //                HoraDeRegistro= DateTime.Now
        //            };
        //            evento.Cupo = evento.Cupo - 1;
        //            _dbContext.Registro.Add(Registro);
        //            _dbContext.Evento.Update(evento);
        //        }
        //        await _dbContext.SaveChangesAsync();
        //    }
        //}
    }
}
