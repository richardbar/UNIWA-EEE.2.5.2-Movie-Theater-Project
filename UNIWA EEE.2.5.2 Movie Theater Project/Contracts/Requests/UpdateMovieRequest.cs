namespace MovieTheaterProject.Contracts.Requests;

public class UpdateMovieRequest
{
    public Guid Id { get; init; }

    public string Name { get; init; } = default!;

    public float Price { get; init; } = .0f;

    public long Duration { get; init; } = default!;
}