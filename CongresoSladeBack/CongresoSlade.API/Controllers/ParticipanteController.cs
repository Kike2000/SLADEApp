using CongresoSlade.Application.DTOs.Request;
using CongresoSlade.Application.Interfaces;
using CongresoSlade.Application.Services;
using CongresoSlade.Infrastructure.Commons.Bases.Request;
using Microsoft.AspNetCore.Mvc;

namespace CongresoSlade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipanteController : Controller
    {
        private readonly IParticipanteApplication _participanteEvento;
        public ParticipanteController(IParticipanteApplication participanteApplication)
        {
            _participanteEvento = participanteApplication;
        }
        [HttpPost]
        public async Task<IActionResult> ListEventos([FromBody] BaseFilterRequest filters)
        {
            var response = await _participanteEvento.ListParticipantes(filters);
            return Ok(response);
        }
        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectEventos()
        {
            var response = await _participanteEvento.ListSelectParticipantes();
            return Ok(response);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterEvento([FromBody] ParticipanteRequestDTO filters)
        {
            var response = await _participanteEvento.RegisterParticipante(filters);
            return Ok(response);
        }
        [HttpPost("Edit/{ParticipanteId}")]
        public async Task<IActionResult> UpdateEvento(Guid ParticipanteId, [FromBody] ParticipanteRequestDTO filters)
        {
            var response = await _participanteEvento.EditParticipante(ParticipanteId, filters);
            return Ok(response);
        }
        [HttpDelete("Remove/{ParticipanteId}")]
        public async Task<IActionResult> RemoveParticipante(Guid ParticipanteId)
        {
            var response = await _participanteEvento.RemoveParticipante(ParticipanteId);
            return Ok(response);
        }

    }
}
