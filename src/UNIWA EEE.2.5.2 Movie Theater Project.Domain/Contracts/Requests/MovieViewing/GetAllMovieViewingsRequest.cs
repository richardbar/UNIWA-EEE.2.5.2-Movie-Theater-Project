namespace MovieTheaterProject.Domain.Contracts.Requests.MovieViewing;

public sealed class GetAllMovieViewingsRequest
{
    public Guid? MovieId { get; init; }

    public Guid? MovieTheaterId { get; init; }
}
