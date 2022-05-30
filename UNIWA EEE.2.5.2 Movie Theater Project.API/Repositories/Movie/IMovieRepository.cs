using MovieTheaterProject.API.Contracts.Data;

namespace MovieTheaterProject.API.Repositories.Movie;

public interface IMovieRepository
{
    Task<bool> CreateAsync(MovieDto movie);

    Task<MovieDto?> GetAsync(Guid id);

    Task<IEnumerable<MovieDto>> GetAllAsync();

    Task<bool> UpdateAsync(MovieDto movie);

    Task<bool> DeleteAsync(Guid id);
}
