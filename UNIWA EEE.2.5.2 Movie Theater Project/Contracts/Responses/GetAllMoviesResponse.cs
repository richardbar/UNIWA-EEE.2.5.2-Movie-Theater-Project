namespace MovieTheaterProject.Contracts.Responses;

public sealed class GetAllMoviesResponse
{
    public IEnumerable<MovieResponse> Movies { get; init; } = Enumerable.Empty<MovieResponse>();
}
