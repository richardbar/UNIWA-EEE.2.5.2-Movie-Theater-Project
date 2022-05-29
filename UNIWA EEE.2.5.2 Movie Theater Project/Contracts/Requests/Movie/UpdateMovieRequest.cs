namespace MovieTheaterProject.Contracts.Requests.Movie;

public class UpdateMovieRequest
{
    public Guid Id { get; init; }

    public string Name { get; init; } = default!;

    public float Price { get; init; } = .0f;

    internal long Duration { get; set; } = default!;
}