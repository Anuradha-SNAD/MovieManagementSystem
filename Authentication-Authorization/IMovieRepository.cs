using MovieManagementSystem.Model;

namespace MovieManagementSystem.Repository
{
    public interface IMovieRepository
    {
        Task Add(Movie movie);
        Task<Movie?> GetById(int id);
        Task<List<Movie>> GetAll();
        Task Update();
        Task Delete(Movie movie);

        Task<List<Movie>> SearchByTitle(string title);

        Task<List<Movie>> SearchByHero(string hero);

        Task<List<Movie>> SearchByDirector(string director);

        Task<List<Movie>> SortByRating();

        Task<List<Movie>> GetMoviesByPage(int page, int size);


    }
}
