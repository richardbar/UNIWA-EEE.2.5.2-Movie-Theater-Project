using MovieTheaterProject.Domain;

namespace MovieTheaterProject.Services;

public interface IMovieService
{
    Task<bool> CreateAsync(Movie movie);

    Task<Movie?> GetAsync(Guid id);

    Task<IEnumerable<Movie>> GetAllAsync();

    Task<bool> UpdateAsync(Movie movie);

    Task<bool> DeleteAsync(Guid id);
}
