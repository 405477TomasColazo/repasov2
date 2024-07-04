using Api.Dtos;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LogginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _loginService.ValidateUserAsync(dto.Email,dto.Password);
            if (token == null) return NotFound();
            return Ok(token);
        }
    }
}
