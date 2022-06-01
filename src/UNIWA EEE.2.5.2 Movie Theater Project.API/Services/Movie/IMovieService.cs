namespace MovieTheaterProject.API.Services.Movie;

public interface IMovieService
{
    Task<bool> CreateAsync(Domain.Entities.Movie movie);

    Task<Domain.Entities.Movie?> GetAsync(Guid id);

    Task<IEnumerable<Domain.Entities.Movie>> GetAllAsync();

    Task<bool> UpdateAsync(Domain.Entities.Movie movie);

    Task<bool> DeleteAsync(Guid id);
}
