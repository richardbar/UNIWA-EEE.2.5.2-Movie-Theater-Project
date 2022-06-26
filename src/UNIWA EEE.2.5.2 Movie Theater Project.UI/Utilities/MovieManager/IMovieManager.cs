using MovieTheaterProject.Domain.Contracts.Data;
using MovieTheaterProject.Domain.Contracts.Responses.Movie;

namespace MovieTheaterProject.UI.Utilities.MovieManager;

public interface IMovieManager
{
    public Task<MovieResponse?> GetMovieById(Guid movieId);

    public Task<MovieResponse[]?> GetAllMovies();

    public Task<MovieResponse?> CreateMovie(string movieName, string movieDescription, float moviePrice, long movieDuration);

    public Task<bool> DeleteMovie(Guid movieId);
}
