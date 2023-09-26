using CongresoSlade.Application.DTOs.Request;
using CongresoSlade.Application.Interfaces;
using CongresoSlade.Infrastructure.Commons.Bases.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CongresoSlade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoApplication _eventoApplication;

        public EventoController(IEventoApplication eventoApplication)
        {
            _eventoApplication = eventoApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ListEventos([FromBody] BaseFilterRequest filters)
        {
            var response = await _eventoApplication.ListEventos(filters);
            return Ok(response);
        }
        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectEventos()
        {
            var response = await _eventoApplication.ListSelectEventos();
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterEvento([FromBody] EventoRequestDTO filters)
        {
            var response = await _eventoApplication.RegisterEvento(filters);
            return Ok(response);
        }
        [HttpPost("Edit/{EventoId}")]
        public async Task<IActionResult> UpdateEvento(Guid EventoId, [FromBody] EventoRequestDTO filters)
        {
            var response = await _eventoApplication.EditEvento(EventoId, filters);
            return Ok(response);
        }
    }
}
