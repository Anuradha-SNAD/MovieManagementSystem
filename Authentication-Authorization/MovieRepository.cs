using Microsoft.EntityFrameworkCore;
using MovieManagementSystem.Data;
using MovieManagementSystem.Model;

namespace MovieManagementSystem.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext context;

        public MovieRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Add(Movie movie)
        {
            await context.movie.AddAsync(movie);
            await context.SaveChangesAsync();
        }

        public async Task<Movie?> GetById(int id)
        {
            return await context.movie.FirstOrDefaultAsync(x => x.MovieId == id);
        }
        
        public async Task<List<Movie>> GetAll()
        {
            return await context.movie.ToListAsync();
        }

        public async Task Update()
        {
            await context.SaveChangesAsync();
        }

        public async Task Delete(Movie movie)
        {
            context.movie.Remove(movie);
            await context.SaveChangesAsync();
        }
        public async Task<List<Movie>> SearchByTitle(string title)
        {
            return await context.movie.Where(m => m.Title.ToLower().Contains(title.ToLower())).ToListAsync();
        }
        public async Task<List<Movie>> SearchByHero(string hero)
        {
            return await context.movie.Where(m => m.Hero.ToLower().Contains(hero.ToLower())).ToListAsync();
        }

        public async Task<List<Movie>> SearchByDirector(string director)
        {
            return await context.movie.Where(m => m.Director.ToLower().Contains(director.ToLower())).ToListAsync();
        }
        public async Task<List<Movie>> SortByRating()
        {
            return await context.movie.OrderByDescending(m => m.Rating).ToListAsync();
        }

        public async Task<List<Movie>> GetMoviesByPage(int page, int size)
        {
            return await context.movie.OrderBy(m => m.MovieId).Skip((page - 1) * size).Take(size).ToListAsync();
        }
    }
}
