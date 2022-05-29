namespace MovieTheaterProject.Contracts.Requests;

public class UpdateMovieTheaterRequest
{
    public Guid Id { get; init; }

    public string Name { get; init; } = default!;

    public ushort Rows { get; init; } = default!;

    public ushort Columns { get; init; } = default!;
}