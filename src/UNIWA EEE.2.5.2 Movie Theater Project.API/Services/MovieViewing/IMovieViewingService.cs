namespace MovieTheaterProject.API.Services.MovieViewing;

public interface IMovieViewingService
{
    Task<bool> CreateAsync(Domain.Entities.MovieViewing movieViewing);

    Task<Domain.Entities.MovieViewing?> GetAsync(Guid id);

    Task<IEnumerable<Domain.Entities.MovieViewing>> GetAllAsync();

    Task<IEnumerable<Domain.Entities.MovieViewing>> GetAllByMovieIdAsync(Guid id);

    Task<IEnumerable<Domain.Entities.MovieViewing>> GetAllByMovieTheaterIdAsync(Guid id);

    Task<bool> DeleteAsync(Guid id);
}
