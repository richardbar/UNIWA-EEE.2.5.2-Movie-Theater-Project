using MovieTheaterProject.Domain;

namespace MovieTheaterProject.Services;

public interface IMovieTheaterService
{
    Task<bool> CreateAsync(MovieTheater movieTheater);

    Task<MovieTheater?> GetAsync(Guid id);

    Task<IEnumerable<MovieTheater>> GetAllAsync();

    Task<bool> UpdateAsync(MovieTheater movieTheater);

    Task<bool> DeleteAsync(Guid id);
}
