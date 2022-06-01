namespace MovieTheaterProject.API.Services.MovieViewing;

public interface IMovieViewingService
{
    Task<bool> CreateAsync(Domain.Entities.MovieViewing movieViewing);

    Task<Domain.Entities.MovieViewing?> GetAsync(Guid id);

    Task<IEnumerable<Domain.Entities.MovieViewing>> GetAllAsync();

    Task<bool> DeleteAsync(Guid id);
}
