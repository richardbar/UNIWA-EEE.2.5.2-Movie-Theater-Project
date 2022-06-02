namespace MovieTheaterProject.Domain.Contracts.Data;

public class MovieDto
{
    public string Id { get; init; } = default!;

    public string Name { get; init; } = default!;

    public string Description { get; init; } = default!;

    public float Price { get; init; } = .0f;

    public long Duration { get; init; } = default!;
}
