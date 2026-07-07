using MovieManagementSystem.DTOs;
using MovieManagementSystem.Model;

namespace MovieManagementSystem.Service
{
    public interface IMovieService
    {
        Task<List<MovieResponseDTO>> GetAll();
        Task<MovieResponseDTO> GetById(int id);
        Task Add(MovieRequestDTO dto);
        Task Update(int id, MovieRequestDTO dto);
        Task Delete(int id);
        Task<List<AudienceMovieResponseDTO>> GetAllAudience();

        Task<AudienceMovieResponseDTO> GetAudienceById(int id);
        Task<List<MovieResponseDTO>> SearchByTitle(string title);

        Task<List<MovieResponseDTO>> SearchByHeroAsync(string hero);

        Task<List<MovieResponseDTO>> SearchByDirector(string director);

        Task<List<MovieResponseDTO>> SortByRating();

        Task<List<MovieResponseDTO>> GetMoviesByPage(int page, int size);
    }
}
