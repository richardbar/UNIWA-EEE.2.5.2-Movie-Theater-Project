namespace MovieTheaterProject.Contracts.Responses;

public sealed class GetAllMovieTheatersResponse
{
    public IEnumerable<MovieTheaterResponse> MovieTheaters { get; init; } = Enumerable.Empty<MovieTheaterResponse>();
}
