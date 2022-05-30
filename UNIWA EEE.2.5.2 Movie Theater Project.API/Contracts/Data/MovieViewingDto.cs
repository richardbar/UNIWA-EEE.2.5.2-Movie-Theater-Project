namespace MovieTheaterProject.API.Contracts.Data;

public class MovieViewingDto
{
    public string Id { get; init; } = default!;

    public string MovieId { get; init; } = default!;

    public string MovieTheaterId { get; init; } = default!;

    public long StartTime { get; init; } = default!;

    public long Duration { get; init; } = default!;
}
