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
    }
}
