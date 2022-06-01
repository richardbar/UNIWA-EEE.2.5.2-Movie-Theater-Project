namespace MovieTheaterProject.API.Services.MovieTheater;

public interface IMovieTheaterService
{
    Task<bool> CreateAsync(Domain.Entities.MovieTheater movieTheater);

    Task<Domain.Entities.MovieTheater?> GetAsync(Guid id);

    Task<IEnumerable<Domain.Entities.MovieTheater>> GetAllAsync();

    Task<bool> UpdateAsync(Domain.Entities.MovieTheater movieTheater);

    Task<bool> DeleteAsync(Guid id);
}
