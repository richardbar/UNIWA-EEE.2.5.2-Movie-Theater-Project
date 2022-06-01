namespace MovieTheaterProject.Domain.Contracts.Responses.MovieTheater;

public sealed class GetAllMovieTheatersResponse
{
    public IEnumerable<MovieTheaterResponse> MovieTheaters { get; init; } = Enumerable.Empty<MovieTheaterResponse>();
}
