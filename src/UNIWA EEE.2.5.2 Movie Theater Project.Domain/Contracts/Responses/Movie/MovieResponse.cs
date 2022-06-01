namespace MovieTheaterProject.Domain.Contracts.Responses.Movie;

public sealed class MovieResponse
{
    public Guid Id { get; init; }

    public string Name { get; init; } = default!;

    public float Price { get; init; } = .0f;

    public long Duration { get; init; }
}
