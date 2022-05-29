namespace MovieTheaterProject.Contracts.Requests;

public class CreateMovieTheaterRequest
{
    public string Name { get; init; } = default!;

    public ushort Rows { get; init; } = default!;

    public ushort Columns { get; init; } = default!;
}
