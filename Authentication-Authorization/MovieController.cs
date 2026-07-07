using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieManagementSystem.DTOs;
using MovieManagementSystem.Service;

namespace MovieManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Producer")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService service;

        public MovieController(IMovieService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieRequestDTO dto)
        {
            await service.Add(dto);
            return Ok("Movie Added Successfully");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieResponseDTO>> GetById(int id)
        {
           var m = await service.GetById(id);
            return Ok(m);
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieResponseDTO>>> GetAll()
        {
            var m = await service.GetAll();
            return Ok(m);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Upate(int id, MovieRequestDTO dto)
        {
            await service.Update(id, dto);
            return Ok("Movie Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await service.Delete(id);
            return Ok("Movie Deleted  Successfully");
        }
    }
}
 