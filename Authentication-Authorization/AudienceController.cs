using Microsoft.AspNetCore.Mvc;
using MovieManagementSystem.DTOs;
using MovieManagementSystem.Service;

namespace MovieManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AudienceController : ControllerBase
    {
        private readonly IMovieService service;

        public AudienceController(IMovieService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AudienceMovieResponseDTO>> GetAudienceById(int id)
        {
            var movie = await service.GetAudienceById(id);
            return Ok(movie);
        }

        [HttpGet]
        public async Task<ActionResult<List<AudienceMovieResponseDTO>>> GetAll()
        {
            var movies = await service.GetAllAudience();
            return Ok(movies);
        }

        [HttpGet("search/title")]
        public async Task<ActionResult<List<MovieResponseDTO>>> SearchByTitle([FromQuery] string title)
        {
            var movies = await service.SearchByTitle(title);

            return Ok(movies);
        }

        [HttpGet("search/hero")]
        public async Task<ActionResult<List<MovieResponseDTO>>> SearchByHero([FromQuery] string hero)
        {
            var movies = await service.SearchByHeroAsync(hero);

            return Ok(movies);
        }

        [HttpGet("search/director")]
        public async Task<ActionResult<List<MovieResponseDTO>>> SearchByDirector([FromQuery] string director)
        {
            var movies = await service.SearchByDirector(director);

            return Ok(movies);
        }

        [HttpGet("sort/rating")]
        public async Task<ActionResult<List<MovieResponseDTO>>> SortByRating()
        {
            var movies = await service.SortByRating();
            return Ok(movies);
        }

        [HttpGet("pagination")]
        public async Task<ActionResult<List<MovieResponseDTO>>> Pagination(int page = 1, int size = 5)
        {
            var movies = await service.GetMoviesByPage(page, size);
            return Ok(movies);
        }
    }
}
