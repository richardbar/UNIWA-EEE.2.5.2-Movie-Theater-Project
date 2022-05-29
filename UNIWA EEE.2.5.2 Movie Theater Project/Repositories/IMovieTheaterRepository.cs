using MovieTheaterProject.Contracts.Data;

namespace MovieTheaterProject.Repositories;

public interface IMovieTheaterRepository
{
    Task<bool> CreateAsync(MovieTheaterDto movieTheater);

    Task<MovieTheaterDto?> GetAsync(Guid id);

    Task<IEnumerable<MovieTheaterDto>> GetAllAsync();

    Task<bool> UpdateAsync(MovieTheaterDto movieTheater);

    Task<bool> DeleteAsync(Guid id);
}
