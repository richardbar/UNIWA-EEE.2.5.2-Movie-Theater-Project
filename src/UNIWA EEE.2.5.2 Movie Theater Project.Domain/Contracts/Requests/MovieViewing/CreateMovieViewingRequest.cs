namespace MovieTheaterProject.Domain.Contracts.Requests.MovieViewing;

public class CreateMovieViewingRequest
{
    public string MovieId { get; init; } = default!;

    public string MovieTheaterId { get; init; } = default!;

    public long StartTime { get; init; } = default!;
}