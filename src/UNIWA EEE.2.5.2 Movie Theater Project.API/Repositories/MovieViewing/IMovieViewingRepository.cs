namespace MovieTheaterProject.API.Repositories.MovieViewing;

public interface IMovieViewingRepository
{
    Task<bool> CreateAsync(MovieViewingDto movieViewing);

    Task<MovieViewingDto?> GetAsync(Guid id);

    Task<IEnumerable<MovieViewingDto>> GetAllAsync();

    Task<IEnumerable<MovieViewingDto>> GetAsyncByMovieId(Guid id);

    Task<IEnumerable<MovieViewingDto>> GetAsyncByMovieTheaterId(Guid id);

    Task<bool> DeleteAsync(Guid id);
}
