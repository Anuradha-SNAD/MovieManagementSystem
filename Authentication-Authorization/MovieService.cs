using MovieManagementSystem.DTOs;
using MovieManagementSystem.Exceptions;
using MovieManagementSystem.Model;
using MovieManagementSystem.Repository;

namespace MovieManagementSystem.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository repository;

        public MovieService(IMovieRepository repository)
        {
            this.repository = repository;
        }

        public async Task Add(MovieRequestDTO dto)
        {
            Movie movie = new Movie()
            {
                Title = dto.Title,
                Budget = dto.Budget,
                Collection = dto.Collection,
                ReleasedDate = dto.ReleasedDate,
                Rating = dto.Rating,
                Hero = dto.Hero,
                Heroine = dto.Heroine,
                Producer = dto.Producer,
                Director = dto.Director,
                Language = dto.Language
            };
            await repository.Add(movie);
        }
        public async Task<MovieResponseDTO> GetById(int id)
        {
           var movie = await repository.GetById(id);
            if(movie == null)
            {
                throw new MovieNotFoundException($"Movie with Id {id} not found.");
            }
            return new MovieResponseDTO
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Budget = movie.Budget,
                Collection = movie.Collection,
                ReleasedDate = movie.ReleasedDate,
                Rating = movie.Rating,
                Hero = movie.Hero,
                Heroine = movie.Heroine,
                Producer = movie.Producer,
                Director = movie.Director,
                Language = movie.Language

            };
        }

        public async Task<List<MovieResponseDTO>> GetAll()
        {
            var m = await repository.GetAll();
            return m.Select(movie => new MovieResponseDTO{
                MovieId = movie.MovieId,
                Title = movie.Title,
                Budget = movie.Budget,
                Collection = movie.Collection,
                ReleasedDate = movie.ReleasedDate,
                Rating = movie.Rating,
                Hero = movie.Hero,
                Heroine = movie.Heroine,
                Producer = movie.Producer,
                Director = movie.Director,
                Language = movie.Language

            }).ToList();
        }

        public async Task Update(int id , MovieRequestDTO dto)
        {
            var movie = await repository.GetById(id);
            if(movie == null)
            {
                throw new MovieNotFoundException($"Movie with Id {id} not found.");
            }
            movie.Title = dto.Title;
            movie.Budget = dto.Budget;
            movie.Collection = dto.Collection;
            movie.ReleasedDate = dto.ReleasedDate;
            movie.Rating = dto.Rating;
            movie.Hero = dto.Hero;
            movie.Heroine = dto.Heroine;
            movie.Producer = dto.Producer;
            movie.Director = dto.Director;
            movie.Language = dto.Language;

            await repository.Update();
        }

        public async Task Delete(int id)
        {
            var movie = await repository.GetById(id);
            if(movie == null)
            {
                throw new MovieNotFoundException($"Movie with Id {id} not found.");
            }
            await repository.Delete(movie);
        }

        public async Task<AudienceMovieResponseDTO> GetAudienceById(int id)
        {
            var m = await repository.GetById(id);
            if(m == null)
            {
                throw new MovieNotFoundException($"Movie with Id {id} not found.");
            }
            return new AudienceMovieResponseDTO
            {
                Title = m.Title,
                Hero = m.Hero,
                Heroine = m.Heroine,
                Director = m.Director,
                ReleasedDate = m.ReleasedDate,
                Rating = m.Rating,
                Language = m.Language
            };
        }

        public async Task<List<AudienceMovieResponseDTO>> GetAllAudience()
        {
            var movies = await repository.GetAll();

            return movies.Select(movie => new AudienceMovieResponseDTO
            {
                Title = movie.Title,
                Hero = movie.Hero,
                Heroine = movie.Heroine,
                Director = movie.Director,
                ReleasedDate = movie.ReleasedDate,
                Rating = movie.Rating,
                Language = movie.Language
            }).ToList();
        }

        public async Task<List<MovieResponseDTO>> SearchByHeroAsync(string hero)
        {
            var movies = await repository.SearchByHero(hero);

            if (!movies.Any())
            {
                throw new MovieNotFoundException($"No movies found for Hero '{hero}'.");
            }

            return movies.Select(movie => new MovieResponseDTO
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Budget = movie.Budget,
                Collection = movie.Collection,
                ReleasedDate = movie.ReleasedDate,
                Rating = movie.Rating,
                Hero = movie.Hero,
                Heroine = movie.Heroine,
                Producer = movie.Producer,
                Director = movie.Director,
                Language = movie.Language
            }).ToList();
        }

        public async Task<List<MovieResponseDTO>> SearchByDirector(string director)
        {
            var movies = await repository.SearchByDirector(director);

            if (!movies.Any())
            {
                throw new MovieNotFoundException($"No movies found for Hero '{director}'.");
            }

            return movies.Select(movie => new MovieResponseDTO
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Budget = movie.Budget,
                Collection = movie.Collection,
                ReleasedDate = movie.ReleasedDate,
                Rating = movie.Rating,
                Hero = movie.Hero,
                Heroine = movie.Heroine,
                Producer = movie.Producer,
                Director = movie.Director,
                Language = movie.Language
            }).ToList();
        }

        public async Task<List<MovieResponseDTO>> SortByRating()
        {
            var movies = await repository.SortByRating();

            return movies.Select(movie => new MovieResponseDTO
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Budget = movie.Budget,
                Collection = movie.Collection,
                ReleasedDate = movie.ReleasedDate,
                Rating = movie.Rating,
                Hero = movie.Hero,
                Heroine = movie.Heroine,
                Producer = movie.Producer,
                Director = movie.Director,
                Language = movie.Language
            }).ToList();
        }

        public async Task<List<MovieResponseDTO>> GetMoviesByPage(int page, int size)
        {
            var movies = await repository.GetMoviesByPage(page, size);

            return movies.Select(movie => new MovieResponseDTO
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Budget = movie.Budget,
                Collection = movie.Collection,
                ReleasedDate = movie.ReleasedDate,
                Rating = movie.Rating,
                Hero = movie.Hero,
                Heroine = movie.Heroine,
                Producer = movie.Producer,
                Director = movie.Director,
                Language = movie.Language
            }).ToList();
        }

        public async Task<List<MovieResponseDTO>> SearchByTitle(string title)
        {
            var movies = await repository.SearchByTitle(title);

            if (!movies.Any())
            {
                throw new MovieNotFoundException($"No movies found with title '{title}'.");
            }

            return movies.Select(movie => new MovieResponseDTO
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Budget = movie.Budget,
                Collection = movie.Collection,
                ReleasedDate = movie.ReleasedDate,
                Rating = movie.Rating,
                Hero = movie.Hero,
                Heroine = movie.Heroine,
                Producer = movie.Producer,
                Director = movie.Director,
                Language = movie.Language
            }).ToList();
        }
    }

}
