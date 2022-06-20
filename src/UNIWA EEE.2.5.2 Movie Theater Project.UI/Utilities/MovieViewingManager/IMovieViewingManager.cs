using MovieTheaterProject.Domain.Contracts.Responses.MovieViewing;

namespace MovieTheaterProject.UI.Utilities.MovieViewingManager;

public interface IMovieViewingManager
{
    public Task<MovieViewingResponse[]?> GetMovieViewingsByMovieId(Guid movieId);

    public Task DeleteMovieViewing(Guid movieViewingId);
}
