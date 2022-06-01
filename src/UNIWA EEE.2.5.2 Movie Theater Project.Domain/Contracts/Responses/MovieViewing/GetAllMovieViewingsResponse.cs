namespace MovieTheaterProject.Domain.Contracts.Responses.MovieViewing;

public sealed class GetAllMovieViewingsResponse
{
    public IEnumerable<MovieViewingResponse> MovieViewings { get; init; } = Enumerable.Empty<MovieViewingResponse>();
}
