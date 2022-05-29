namespace MovieTheaterProject.Services.MovieTheater;

public interface IMovieTheaterService
{
    Task<bool> CreateAsync(Domain.MovieTheater movieTheater);

    Task<Domain.MovieTheater?> GetAsync(Guid id);

    Task<IEnumerable<Domain.MovieTheater>> GetAllAsync();

    Task<bool> UpdateAsync(Domain.MovieTheater movieTheater);

    Task<bool> DeleteAsync(Guid id);
}
