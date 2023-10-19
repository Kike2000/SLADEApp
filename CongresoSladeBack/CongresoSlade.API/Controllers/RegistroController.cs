using CongresoSlade.Application.DTOs.Request;
using CongresoSlade.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CongresoSlade.API.Controllers
{
    public class RegistroController : Controller
    {

        private readonly IRegistroApplication _registroApplication;
        public RegistroController(IRegistroApplication registroApplication)
        {
            _registroApplication = registroApplication;

        }
        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectRegistros()
        {
            var response = await _registroApplication.ListSelectRegistros();
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegistroRequestDTO request)
        {
            var response = await _registroApplication.RegisterRegistro(request);
            return Ok(response);
        }

        [HttpPost("Remove/{AreaId}")]
        public async Task<IActionResult> RemoveEvento(Guid AreaId)
        {
            var response = await _registroApplication.RemoveRegistro(AreaId);
            return Ok(response);
        }

        [HttpPost("Edit/{AreaId}")]
        public async Task<IActionResult> EditEvento(Guid AreaId, RegistroRequestDTO filters)
        {
            var response = await _registroApplication.EditRegistro(AreaId, filters);
            return Ok(response);
        }
    }
}
