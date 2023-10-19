using CongresoSlade.Application.DTOs.Request;
using CongresoSlade.Application.Interfaces;
using CongresoSlade.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CongresoSlade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreaController : Controller
    {
        private readonly IAreaApplication _areaApplication;
        public AreaController(IAreaApplication areaApplication)
        {
            _areaApplication = areaApplication;
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectEventos()
        {
            var response = await _areaApplication.ListSelectAreas();
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] AreaRequestDTO request)
        {
            var response = await _areaApplication.RegisterArea(request);
            return Ok(response);
        }

        [HttpPost("Remove/{AreaId}")]
        public async Task<IActionResult> RemoveEvento(Guid AreaId)
        {
            var response = await _areaApplication.RemoveArea(AreaId);
            return Ok(response);
        }

        [HttpPost("Edit/{AreaId}")]
        public async Task<IActionResult> EditEvento(Guid AreaId, AreaRequestDTO filters)
        {
            var response = await _areaApplication.EditArea(AreaId, filters);
            return Ok(response);
        }
    }
}
