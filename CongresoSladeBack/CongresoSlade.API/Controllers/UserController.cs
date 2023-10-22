using CongresoSlade.Application.DTOs.Request;
using CongresoSlade.Application.Interfaces;
using CongresoSlade.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CongresoSlade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserApplication _userApplication;
        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        //[HttpGet("Select")]
        //public async Task<IActionResult> ListSelectEventos()
        //{
        //    var response = await _userApplication.ListSelectUsers();
        //    return Ok(response);
        //}

        //[HttpPost("Register")]
        //public async Task<IActionResult> Register([FromBody] UserRequestDTO request)
        //{
        //    var response = await _userApplication.RegisterUser(request);
        //    return Ok(response);
        //}
    }
}
