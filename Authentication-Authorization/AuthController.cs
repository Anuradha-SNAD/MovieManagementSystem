using Microsoft.AspNetCore.Mvc;
using MovieManagementSystem.DTOs;
using MovieManagementSystem.Service;

namespace MovieManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IProducerService service;

        public AuthController(IProducerService service)
        {
            this.service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDTO dto)
        {
            await service.Register(dto);

            return Ok("Producer Registered Successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDTO dto)
        {
            var token = await service.LoginAsync(dto);

            return Ok(token);
        }
    }
}
