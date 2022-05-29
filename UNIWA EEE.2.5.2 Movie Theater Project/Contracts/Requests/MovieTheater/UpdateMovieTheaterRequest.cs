namespace MovieTheaterProject.Contracts.Requests.MovieTheater;

public class UpdateMovieTheaterRequest
{
    public Guid Id { get; init; }

    public string Name { get; init; } = default!;

    internal ushort Rows { get; set; } = default!;

    internal ushort Columns { get; set; } = default!;
}