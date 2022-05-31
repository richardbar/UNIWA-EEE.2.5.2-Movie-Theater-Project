using MovieTheaterProject.API.Contracts.Data;

namespace MovieTheaterProject.API.Repositories.MovieViewing;

public interface IMovieViewingRepository
{
    Task<bool> CreateAsync(MovieViewingDto movieViewing);

    Task<MovieViewingDto?> GetAsync(Guid id);

    Task<IEnumerable<MovieViewingDto>> GetAllAsync();

    Task<bool> DeleteAsync(Guid id);
}
