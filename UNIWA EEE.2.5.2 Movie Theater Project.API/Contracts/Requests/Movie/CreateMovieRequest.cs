namespace MovieTheaterProject.API.Contracts.Requests.Movie;

public class CreateMovieRequest
{
    public string Name { get; init; } = default!;

    public float Price { get; init; } = .0f;

    public long Duration { get; init; } = default!;
}