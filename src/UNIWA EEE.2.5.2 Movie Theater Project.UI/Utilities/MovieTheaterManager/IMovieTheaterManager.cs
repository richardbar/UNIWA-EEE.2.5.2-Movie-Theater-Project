using MovieTheaterProject.Domain.Contracts.Responses.MovieTheater;

namespace MovieTheaterProject.UI.Utilities.MovieTheaterManager;

public interface IMovieTheaterManager
{
    public Task<MovieTheaterResponse?> GetMovieTheaterById(Guid movieTheaterId);

    public Task<MovieTheaterResponse[]?> GetAllMovieTheaters();
}
