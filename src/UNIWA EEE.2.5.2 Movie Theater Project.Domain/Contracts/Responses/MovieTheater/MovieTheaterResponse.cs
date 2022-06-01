namespace MovieTheaterProject.Domain.Contracts.Responses.MovieTheater;

public sealed class MovieTheaterResponse
{
    public Guid Id { get; init; }

    public string Name { get; init; } = default!;

    public ushort Rows { get; init; } = default!;

    public ushort Columns { get; init; } = default!;
}
