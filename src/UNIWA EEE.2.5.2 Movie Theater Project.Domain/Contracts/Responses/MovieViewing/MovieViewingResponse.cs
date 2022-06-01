namespace MovieTheaterProject.Domain.Contracts.Responses.MovieViewing;

public sealed class MovieViewingResponse
{
    public Guid Id { get; init; }

    public Guid MovieId { get; init; } = default!;

    public Guid MovieTheaterId { get; init; } = default!;

    public long StartTime { get; init; } = default!;

    public long Duration { get; init; } = default!;
}
