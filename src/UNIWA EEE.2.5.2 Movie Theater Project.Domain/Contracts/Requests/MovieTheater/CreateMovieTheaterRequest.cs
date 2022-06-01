namespace MovieTheaterProject.Domain.Contracts.Requests.MovieTheater;

public class CreateMovieTheaterRequest
{
    public string Name { get; init; } = default!;

    public ushort Rows { get; init; } = default!;

    public ushort Columns { get; init; } = default!;
}
