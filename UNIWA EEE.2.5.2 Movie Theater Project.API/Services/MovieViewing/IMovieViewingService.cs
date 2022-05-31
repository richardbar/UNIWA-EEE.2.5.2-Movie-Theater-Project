namespace MovieTheaterProject.API.Services.MovieViewing;

public interface IMovieViewingService
{
    Task<bool> CreateAsync(Domain.MovieViewing movieViewing);

    Task<Domain.MovieViewing?> GetAsync(Guid id);

    Task<IEnumerable<Domain.MovieViewing>> GetAllAsync();

    Task<bool> DeleteAsync(Guid id);
}
