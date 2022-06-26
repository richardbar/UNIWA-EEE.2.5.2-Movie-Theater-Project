using MovieTheaterProject.Domain.Contracts.Responses.MovieViewing;

namespace MovieTheaterProject.UI.Utilities.MovieViewingManager;

public interface IMovieViewingManager
{
    public Task<MovieViewingResponse?> GetMovieViewingById(Guid movieViewingId);

    public Task<MovieViewingResponse[]?> GetMovieViewingsByMovieId(Guid movieId);

    public Task<MovieViewingResponse[]?> GetAllMovieViewings();

    public Task<MovieViewingResponse?> CreateMovieViewing(Guid movieId, Guid movieTheaterId, long startTime);

    public Task DeleteMovieViewing(Guid movieViewingId);
}
