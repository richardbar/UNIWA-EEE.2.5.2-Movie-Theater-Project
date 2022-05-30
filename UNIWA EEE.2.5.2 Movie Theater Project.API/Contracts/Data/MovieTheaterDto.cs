namespace MovieTheaterProject.API.Contracts.Data;

public class MovieTheaterDto
{
    public string Id { get; init; } = default!;

    public string Name { get; init; } = default!;

    public ushort Rows { get; init; } = default!;

    public ushort Columns { get; init; } = default!;
}
