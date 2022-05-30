using MovieTheaterProject.API.Domain;

namespace MovieTheaterProject.API.Services.Movie;

public interface IMovieService
{
    Task<bool> CreateAsync(Domain.Movie movie);

    Task<Domain.Movie?> GetAsync(Guid id);

    Task<IEnumerable<Domain.Movie>> GetAllAsync();

    Task<bool> UpdateAsync(Domain.Movie movie);

    Task<bool> DeleteAsync(Guid id);
}
