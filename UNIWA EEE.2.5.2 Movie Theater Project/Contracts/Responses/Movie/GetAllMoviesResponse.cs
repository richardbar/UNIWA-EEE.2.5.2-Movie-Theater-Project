namespace MovieTheaterProject.Contracts.Responses.Movie;

public sealed class GetAllMoviesResponse
{
    public IEnumerable<MovieResponse> Movies { get; init; } = Enumerable.Empty<MovieResponse>();
}
