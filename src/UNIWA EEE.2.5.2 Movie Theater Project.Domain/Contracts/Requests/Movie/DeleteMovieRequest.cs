namespace MovieTheaterProject.Domain.Contracts.Requests.Movie;

public sealed class DeleteMovieRequest
{
    public Guid Id { get; init; }
}
